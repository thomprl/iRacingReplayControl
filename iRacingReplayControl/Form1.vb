﻿Imports iRacingSdkWrapper
Imports iRSDKSharp
Imports System.Globalization

''' <summary>
''' 
''' </summary>
Public Class ReplayForm
    Private ReadOnly sdkWrapper As SdkWrapper
    Private ReadOnly iRacingSdk As iRacingSDK
    Private drivers As List(Of Driver)
    Private cameras As List(Of Camera)
    Private isUpdatingDrivers As Boolean
    Private binding As BindingSource
    Private currentSessionNum As Integer
    Private playSpeed As Integer
    Private currentReplayStatus As String
    Private isCamUpdate As Boolean = False



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sdkWrapper.Start()
        If sdkWrapper.IsRunning Then
        End If
        Me.StatusChanged()

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Create a new instance of the SdkWrapper object
        sdkWrapper = New SdkWrapper()
        iRacingSdk = New iRacingSDK()

        ' Set some properties
        sdkWrapper.EventRaiseType = SdkWrapper.EventRaiseTypes.CurrentThread
        sdkWrapper.TelemetryUpdateFrequency = 1

        ' Listen for various events
        AddHandler sdkWrapper.Connected, AddressOf wrapper_Connected
        AddHandler sdkWrapper.Disconnected, AddressOf wrapper_Disconnected
        AddHandler sdkWrapper.SessionInfoUpdated, AddressOf wrapper_SessionInfoUpdated
        AddHandler sdkWrapper.TelemetryUpdated, AddressOf wrapper_TelemetryUpdated


        ' Bind a list of drivers to the grid
        binding = New BindingSource()
        drivers = New List(Of Driver)()
        cameras = New List(Of Camera)()
        binding.DataSource = drivers
        '        driversGrid.DataSource = binding


    End Sub

    Private Sub wrapper_Connected(sender As Object, e As EventArgs)
        Me.StatusChanged()
    End Sub

    Private Sub wrapper_Disconnected(sender As Object, e As EventArgs)
        Me.StatusChanged()
    End Sub

    Private Sub StatusChanged()
        If sdkWrapper.IsConnected Then
            If sdkWrapper.IsRunning Then
                ToolStripStatusLabel1.Text = "Status: connected!"
            Else
                ToolStripStatusLabel1.Text = "Status: disconnected."
            End If
        Else
            If sdkWrapper.IsRunning Then
                ToolStripStatusLabel1.Text = "Status: disconnected, waiting for sim..."
            Else
                ToolStripStatusLabel1.Text = "Status: disconnected"
            End If
        End If
    End Sub

#Region "Events"

    Private Sub wrapper_SessionInfoUpdated(sender As Object, e As SdkWrapper.SessionInfoUpdatedEventArgs)
        ' Indicate that we are updating the drivers list
        isUpdatingDrivers = True
        Dim query As YamlQuery = e.SessionInfo("WeekendInfo")
        'statusLabel.Text = query("TrackName").GetValue


        ' Parse the Drivers section of the session info into a list of drivers
        Me.ParseDrivers(e.SessionInfo)

        ' Parse the ResultsPositions section of the session info to get the positions and times of drivers
        Me.ParseTimes(e.SessionInfo)

        ' Indicate we are finished updating drivers
        isUpdatingDrivers = False
        Me.ParseCameras(e.SessionInfo)

    End Sub

    Private Sub wrapper_TelemetryUpdated(sender As Object, e As SdkWrapper.TelemetryUpdatedEventArgs)
        ' Besides the driver details found in the session info, there's also things in the telemetry
        ' that are properties of a driver, such as their lap, lap distance, track surface, distance relative
        ' to yourself and more.
        ' We update the existing list of drivers with the telemetry values here.

        ' If we are currently renewing the drivers list it makes little sense to update the existing drivers
        ' because they will change anyway
        If isUpdatingDrivers Then
            Return
        End If

        ' Store the current session number so we know which session to read 
        ' There can be multiple sessions in a server (practice, Q, race, or warmup, race, etc).
        currentSessionNum = e.TelemetryInfo.SessionNum.Value

        Me.UpdateDriversTelemetry(e.TelemetryInfo)
        If Not isCamUpdate Then
            Me.UpdateCameraFromTelemetry(e.TelemetryInfo)
        End If

    End Sub

#End Region

#Region "Cameras"
    Private Sub ParseCameras(sessionInfo As SessionInfo)
        Dim camera As Camera
        Dim newCameras As New List(Of Camera)
        Dim id As Integer = 1

        Do
            camera = Nothing
            Dim query As YamlQuery = sessionInfo("CameraInfo")("Groups")("GroupNum", id)

            Dim groupName As String = query("GroupName").GetValue()
            If groupName IsNot Nothing Then
                If cameras IsNot Nothing Then
                    camera = cameras.FirstOrDefault(Function(d) d.GroupName = groupName)
                End If

                If camera Is Nothing Then
                    ' Or create a new Driver if we didn't find him before
                    camera = New Camera()
                    camera.GroupNum = Integer.Parse(query("GroupNum").GetValue("0")) ' default value 0
                    camera.GroupName = groupName
                End If
                newCameras.Add(camera)
                ComboBox1.Items.Add(camera.GroupName)
            End If
            id += 1
        Loop While camera IsNot Nothing

        If newCameras IsNot Nothing Then
            If cameras IsNot Nothing Then
                cameras.Clear()
            End If
            cameras.AddRange(newCameras)
        End If
        'Dim cameraIdx = cameras.FindIndex(Function(d) d.GroupName = "TV1")
        'ComboBox1.SelectedIndex = cameraIdx
    End Sub
#End Region


#Region "Drivers"

    ' Parse the YAML DriverInfo section that contains information such as driver id, name, license, car number, etc.
    Private Sub ParseDrivers(sessionInfo As SessionInfo)
        ' This string is used for every property of the driver
        ' {0} is replaced by the driver ID
        ' {1} is replaced by the property key
        ' The result is a string like:         DriverInfo:Drivers:CarIdx:{17}CarNumber: 
        ' which is the correct way to request the property 'CarNumber' from the driver with id 17.
        Const driverYamlPath As String = "DriverInfo:Drivers:CarIdx:{{{0}}}{1}:"

        Dim id As Integer = 0
        Dim driver As Driver

        Dim newDrivers = New List(Of Driver)()


        ' Loop through drivers until none are found anymore
        Do
            driver = Nothing

            ' Construct a yaml query that finds each driver and his info in the Session Info yaml string
            ' This query can be re-used for every property for one driver (with the specified id)
            Dim query As YamlQuery = sessionInfo("DriverInfo")("Drivers")("CarIdx", id)

            ' Try to get the UserName of the driver (because its the first value given)
            ' If the UserName value is not found (name == null) then we found all drivers and we can stop
            Dim name As String = query("UserName").GetValue()
            If name IsNot Nothing Then
                ' Find this driver in the list
                ' This strange "Function(d)" syntax is called a lambda expression and is short for a loop through all drivers
                ' Read as: select the first driver 'd', if any, whose Name is equal to name.
                driver = drivers.FirstOrDefault(Function(d) d.Name = name)

                If driver Is Nothing Then
                    ' Or create a new Driver if we didn't find him before
                    driver = New Driver()
                    driver.Id = id
                    driver.Name = name
                    driver.CustomerId = Integer.Parse(query("UserID").GetValue("0")) ' default value 0
                    driver.Number = query("CarNumber").GetValue("").TrimStart(""""c).TrimEnd(""""c) ' trim the quotes
                    driver.ClassId = Integer.Parse(query("CarClassID").GetValue("0"))
                    driver.CarPath = query("CarPath").GetValue()
                    driver.CarClassRelSpeed = Integer.Parse(query("CarClassRelSpeed").GetValue("0"))
                    driver.Rating = Integer.Parse(query("IRating").GetValue("0"))
                End If
                newDrivers.Add(driver)

                id += 1
            End If
        Loop While driver IsNot Nothing


        ' Replace old list of drivers with new list of drivers and update the grid
        drivers.Clear()
        drivers.AddRange(newDrivers)

        Me.UpdateDriversGrid()
    End Sub

    ' Parse the YAML SessionInfo section that contains information such as lap times, position, etc.
    Private Sub ParseTimes(sessionInfo As SessionInfo)

        Dim position As Integer = 1
        Dim driver As Driver = Nothing


        ' Loop through positions starting at 1 until no more are found
        Do
            driver = Nothing

            ' Construct a yaml query that we can re-use again
            Dim query As YamlQuery = sessionInfo("SessionInfo")("Sessions")("SessionNum", currentSessionNum) _
                ("ResultsPositions")("Position", position)


            ' Find the car id belonging to the current position
            Dim idString As String = query("CarIdx").GetValue()
            If idString IsNot Nothing Then
                Dim id As Integer = Integer.Parse(idString)

                ' Find the corresponding driver from the list
                ' This strange " => " syntax is called a lambda expression and is short for a loop through all drivers
                ' Read as: select the first driver 'd', if any, whose Id is equal to id.
                driver = drivers.FirstOrDefault(Function(d) d.Id = id)

                If driver IsNot Nothing Then
                    driver.Position = position
                    driver.FastestLapTime = Single.Parse(query("FastestTime").GetValue("0"), CultureInfo.InvariantCulture)
                    driver.LastLapTime = Single.Parse(query("LastTime").GetValue("0"), CultureInfo.InvariantCulture)
                End If

                position += 1

            End If
        Loop While driver IsNot Nothing
    End Sub
    Private Sub UpdateCameraFromTelemetry(info As TelemetryInfo)
        Dim camGroupNumber = info.CamGroupNumber.Value
        If cameras.Count > 0 Then
            ComboBox1.SelectedIndex = cameras.FindIndex(Function(d) d.GroupNum = camGroupNumber)
            isCamUpdate = True
        End If
    End Sub

    Private Sub UpdateDriversTelemetry(info As TelemetryInfo)
        ' Get your own driver entry
        ' This strange " => " syntax is called a lambda expression and is short for a loop through all drivers
        Dim [me] As Driver = drivers.FirstOrDefault(Function(d) d.Id = sdkWrapper.DriverId)

        ' Get arrays of the laps, distances, track surfaces of every driver
        Dim laps = info.CarIdxLap.Value
        Dim lapDistances = info.CarIdxLapDistPct.Value
        Dim trackSurfaces = info.CarIdxTrackSurface.Value

        ' Loop through the list of current drivers
        For Each driver As Driver In drivers
            ' Set the lap, distance, tracksurface belonging to this driver
            driver.Lap = laps(driver.Id)
            driver.LapDistance = lapDistances(driver.Id)
            driver.TrackSurface = trackSurfaces(driver.Id)

            ' If your own driver exists, use it to calculate the relative distance between you and the other driver
            If [me] IsNot Nothing Then
                Dim relative = driver.LapDistance - [me].LapDistance

                ' If driver is more than half the track behind, subtract 100% track length
                ' and vice versa
                If relative > 0.5 Then
                    relative -= 1
                ElseIf relative < -0.5 Then
                    relative += 1
                End If

                driver.RelativeLapDistance = relative
            Else
                driver.RelativeLapDistance = -1
            End If
        Next

        Me.UpdateDriversGrid()
    End Sub

    Private Sub UpdateDriversGrid()
        binding.ResetBindings(False)
    End Sub

#End Region

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        sdkWrapper.[Stop]()
    End Sub


    'Private Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click
    ' If the wrapper is running, stop it. Otherwise, start it.
    '        If sdkWrapper.IsRunning Then
    '       sdkWrapper.[Stop]()
    '      startButton.Text = "Start"
    '     Else
    '    sdkWrapper.Start()
    '   startButton.Text = "Stop"
    '  End If
    ' Me.StatusChanged()
    'End Sub


    'PlaySpeeds.Add(New PlaySpeed { Id = -1, Name = "Normal" });
    'PlaySpeeds.Add(New PlaySpeed { Id = 1, Name = "1/2x" });
    'PlaySpeeds.Add(New PlaySpeed { Id = 2, Name = "1/3x" });
    'PlaySpeeds.Add(New PlaySpeed { Id = 3, Name = "1/4x" });
    'PlaySpeeds.Add(New PlaySpeed { Id = 4, Name = "1/5x" });
    'PlaySpeeds.Add(New PlaySpeed { Id = 5, Name = "1/6x" });
    'PlaySpeeds.Add(New PlaySpeed { Id = 6, Name = "1/7x" });
    'PlaySpeeds.Add(New PlaySpeed { Id = 7, Name = "1/8x" });
    'PlaySpeeds.Add(New PlaySpeed { Id = 9, Name = "1/10x" });
    'PlaySpeeds.Add(New PlaySpeed { Id = 15, Name = "1/16x" });

    'currentReplayStautus = 0 'play
    'currentReplayStautus = 1 'slomo

    Private Sub playPicture_Click(sender As Object, e As EventArgs) Handles playPicture.Click
        If sdkWrapper.IsConnected Then
            playPicture.Enabled = False
            currentReplayStatus = 0 'play
            playSpeed = 1 'normal speed
            iRacingSdk.BroadcastMessage(BroadcastMessageTypes.ReplaySetPlaySpeed, playSpeed, currentReplayStatus)
            playPicture.Enabled = True
        End If
    End Sub

    Private Sub pausePicture_Click(sender As Object, e As EventArgs) Handles pausePicture.Click
        If sdkWrapper.IsConnected Then
            pausePicture.Enabled = False
            currentReplayStatus = 0 'pause
            playSpeed = 0 'speed
            iRacingSdk.BroadcastMessage(BroadcastMessageTypes.ReplaySetPlaySpeed, playSpeed, currentReplayStatus)
            pausePicture.Enabled = True
        End If
    End Sub

    Private Sub rewindPicture_Click(sender As Object, e As EventArgs) Handles rewindPicture.Click
        If sdkWrapper.IsConnected Then
            rewindPicture.Enabled = False
            If playSpeed <= 0 And currentReplayStatus = 0 Then
                playSpeed -= 1 'speed
            Else
                playSpeed = -1
            End If
            currentReplayStatus = 0  'play
            iRacingSdk.BroadcastMessage(BroadcastMessageTypes.ReplaySetPlaySpeed, playSpeed, currentReplayStatus)
            rewindPicture.Enabled = True
        End If
    End Sub

    Private Sub fastFowardPicture_Click(sender As Object, e As EventArgs) Handles fastFowardPicture.Click
        If sdkWrapper.IsConnected Then
            fastFowardPicture.Enabled = False
            If playSpeed >= 0 And currentReplayStatus = 0 Then
                playSpeed += 1 'speed
            Else
                playSpeed = 1
            End If
            currentReplayStatus = 0  'play
            iRacingSdk.BroadcastMessage(BroadcastMessageTypes.ReplaySetPlaySpeed, playSpeed, currentReplayStatus)
            fastFowardPicture.Enabled = True
        End If
    End Sub

    Private Sub endPicture_Click(sender As Object, e As EventArgs) Handles endPicture.Click
        iRacingSdk.BroadcastMessage(BroadcastMessageTypes.ReplaySearch, iRSDKSharp.ReplayPositionModeTypes.Current, 0)
    End Sub

    Private Sub beginPicture_Click(sender As Object, e As EventArgs) Handles beginPicture.Click
        iRacingSdk.BroadcastMessage(BroadcastMessageTypes.ReplaySearch, iRSDKSharp.ReplayPositionModeTypes.Begin, 0)
    End Sub

    Private Sub slowMoRewindPicture_Click(sender As Object, e As EventArgs) Handles slowMoRewindPicture.Click
        If sdkWrapper.IsConnected Then
            slowMoRewindPicture.Enabled = False
            If playSpeed <= 0 And currentReplayStatus = 1 Then
                playSpeed -= 1 'speed
            Else
                playSpeed = -1
            End If
            currentReplayStatus = 1  'slow-mo
            iRacingSdk.BroadcastMessage(BroadcastMessageTypes.ReplaySetPlaySpeed, playSpeed, currentReplayStatus)
            slowMoRewindPicture.Enabled = True
        End If

    End Sub

    Private Sub slowMoForwardPicture_Click(sender As Object, e As EventArgs) Handles slowMoForwardPicture.Click
        If sdkWrapper.IsConnected Then
            fastFowardPicture.Enabled = False
            If playSpeed >= 0 And currentReplayStatus = 1 Then
                playSpeed += 1 'speed
            Else
                playSpeed = 1
            End If
            currentReplayStatus = 1  'slow-mo
            iRacingSdk.BroadcastMessage(BroadcastMessageTypes.ReplaySetPlaySpeed, playSpeed, currentReplayStatus)
            fastFowardPicture.Enabled = True
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class
