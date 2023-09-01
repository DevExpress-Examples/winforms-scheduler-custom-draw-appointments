Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
#Region "#usings"
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Drawing
Imports System.Drawing.Drawing2D

#End Region  ' #usings
Namespace CustomDrawDemo

    Public Partial Class Form1
        Inherits Form

#Region "InitialDataConstants"
        Public Shared RandomInstance As Random = New Random()

        Public Shared Users As String() = New String() {"Peter Dolan", "Ryan Fischer", "Richard Fisher", "Tom Hamlett", "Mark Hamilton", "Steve Lee", "Jimmy Lewis", "Jeffrey W McClain", "Andrew Miller", "Dave Murrel", "Bert Parkins", "Mike Roller", "Ray Shipman", "Paul Bailey", "Brad Barnes", "Carl Lucas", "Jerry Campbell"}

#End Region
        Private colorArray As Color() = {Color.Red, Color.Green, Color.Blue, Color.Black}

        Public Sub New()
            InitializeComponent()
            FillResources(schedulerStorage1, 5)
            InitAppointments()
            schedulerControl1.Start = Date.Now
            schedulerControl1.ActiveViewType = SchedulerViewType.Timeline
            schedulerControl1.Appearance.Appointment.ForeColor = Color.Gray
            schedulerControl1.TimelineView.AppointmentDisplayOptions.SnapToCellsMode = AppointmentSnapToCellsMode.Never
            schedulerControl1.TimelineView.AppointmentDisplayOptions.StatusDisplayType = AppointmentStatusDisplayType.Bounds
            schedulerControl1.DayView.AppointmentDisplayOptions.SnapToCellsMode = AppointmentSnapToCellsMode.Never
            schedulerControl1.DayView.AppointmentDisplayOptions.StatusDisplayType = AppointmentStatusDisplayType.Bounds
            schedulerControl1.TimelineView.Scales.Clear()
            schedulerControl1.TimelineView.Scales.Add(New TimeScaleDay())
            schedulerControl1.TimelineView.Scales.Add(New TimeScaleHour())
            schedulerControl1.TimelineView.Scales(1).Width = 100
            UpdateControls()
        End Sub

#Region "InitialDataLoad"
        Private Sub FillResources(ByVal storage As SchedulerStorage, ByVal count As Integer)
            Dim resources As ResourceCollection = storage.Resources.Items
            storage.BeginUpdate()
            Try
                Dim cnt As Integer = Math.Min(count, Users.Length)
                For i As Integer = 1 To cnt
                    resources.Add(New Resource(Guid.NewGuid(), Users(i - 1)))
                Next
            Finally
                storage.EndUpdate()
            End Try
        End Sub

        Private Sub InitAppointments()
            schedulerStorage1.Appointments.Mappings.Start = "StartTime"
            schedulerStorage1.Appointments.Mappings.End = "EndTime"
            schedulerStorage1.Appointments.Mappings.Subject = "Subject"
            schedulerStorage1.Appointments.Mappings.AllDay = "AllDay"
            schedulerStorage1.Appointments.Mappings.Description = "Description"
            schedulerStorage1.Appointments.Mappings.Label = "Label"
            schedulerStorage1.Appointments.Mappings.Location = "Location"
            schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo"
            schedulerStorage1.Appointments.Mappings.ReminderInfo = "ReminderInfo"
            schedulerStorage1.Appointments.Mappings.ResourceId = "OwnerId"
            schedulerStorage1.Appointments.Mappings.Status = "Status"
            schedulerStorage1.Appointments.Mappings.Type = "EventType"
            Dim eventList As CustomEventList = New CustomEventList()
            GenerateEvents(eventList)
            schedulerStorage1.Appointments.DataSource = eventList
        End Sub

        Private Sub GenerateEvents(ByVal eventList As CustomEventList)
            Dim count As Integer = schedulerStorage1.Resources.Count
            For i As Integer = 0 To count - 1
                Dim resource As Resource = schedulerStorage1.Resources(i)
                Dim subjPrefix As String = resource.Caption & "'s "
                eventList.Add(CreateEvent(eventList, subjPrefix & "meeting", resource.Id, 2, 5))
                eventList.Add(CreateEvent(eventList, subjPrefix & "travel", resource.Id, 3, 6))
                eventList.Add(CreateEvent(eventList, subjPrefix & "phone call", resource.Id, 0, 10))
            Next
        End Sub

        Private Function CreateEvent(ByVal eventList As CustomEventList, ByVal subject As String, ByVal resourceId As Object, ByVal status As Integer, ByVal label As Integer) As CustomEvent
            Dim apt As CustomEvent = New CustomEvent(eventList)
            apt.Subject = subject
            apt.OwnerId = resourceId
            Dim rnd As Random = RandomInstance
            Dim rangeInMinutes As Integer = 60 * 24
            apt.StartTime = Date.Today + TimeSpan.FromMinutes(rnd.Next(0, rangeInMinutes))
            apt.EndTime = apt.StartTime + TimeSpan.FromMinutes(rnd.Next(0, rangeInMinutes \ 4))
            apt.Status = status
            apt.Label = label
            Return apt
        End Function

#End Region
#Region "Update Controls"
        Private Sub UpdateControls()
            cbView.EditValue = schedulerControl1.ActiveViewType
            rgrpGrouping.EditValue = schedulerControl1.GroupType
        End Sub

        Private Sub rgrpGrouping_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
            schedulerControl1.GroupType = CType(rgrpGrouping.EditValue, SchedulerGroupType)
        End Sub

        Private Sub schedulerControl_ActiveViewChanged(ByVal sender As Object, ByVal e As EventArgs)
            cbView.EditValue = schedulerControl1.ActiveViewType
        End Sub

        Private Sub cbView_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
            schedulerControl1.ActiveViewType = CType(cbView.EditValue, SchedulerViewType)
        End Sub

#End Region
#Region "#CustomDrawAppointment"
        Private Sub schedulerControl1_CustomDrawAppointment(ByVal sender As Object, ByVal e As CustomDrawObjectEventArgs)
            Dim tlvi As TimeLineAppointmentViewInfo = TryCast(e.ObjectInfo, TimeLineAppointmentViewInfo)
            ' This code works only for the Timeline View.
            If tlvi IsNot Nothing Then
                Dim r As Rectangle = e.Bounds
                r.X += 3
                r.Y += 3
                Dim s As String() = tlvi.Appointment.Subject.Split(" "c)
                For i As Integer = 0 To s.Length - 1
                    e.Cache.DrawString(s(i), tlvi.Appearance.Font, New SolidBrush(colorArray(i)), r, StringFormat.GenericDefault)
                    Dim shift As SizeF = e.Graphics.MeasureString(s(i) & " ", tlvi.Appearance.Font)
                    r.X += CInt(shift.Width)
                Next

                e.Handled = True
            End If
        End Sub

#End Region  ' #CustomDrawAppointment
#Region "#CustomDrawAppointmentBackground"
        Private Sub schedulerControl1_CustomDrawAppointmentBackground(ByVal sender As Object, ByVal e As CustomDrawObjectEventArgs)
            Dim aptViewInfo As DevExpress.XtraScheduler.Drawing.AppointmentViewInfo = TryCast(e.ObjectInfo, DevExpress.XtraScheduler.Drawing.AppointmentViewInfo)
            If aptViewInfo Is Nothing Then Return
            If aptViewInfo.Selected Then
                Dim r As Rectangle = e.Bounds
                Dim brRect As Brush = e.Cache.GetSolidBrush(aptViewInfo.Status.Color)
                FillRoundedRect(e.Graphics, brRect, r, 5)
                r.Inflate(-3, -3)
                Dim c As Color = Invert(aptViewInfo.Appearance.BackColor)
                Dim br As Brush = e.Cache.GetSolidBrush(c)
                FillRoundedRect(e.Graphics, br, r, 5)
                e.Handled = True
            End If
        End Sub

        Public Function Invert(ByVal srcColor As Color) As Color
            Dim r As Byte = CByte(Not srcColor.R)
            Dim g As Byte = CByte(Not srcColor.G)
            Dim b As Byte = CByte(Not srcColor.B)
            Return Color.FromArgb(srcColor.A, r, g, b)
        End Function

        Private Sub FillRoundedRect(ByVal gr As Graphics, ByVal br As Brush, ByVal r As Rectangle, ByVal roundRadius As Integer)
            Using rgn As Region = New Region(CreateRoundedRectPath(r, roundRadius))
                gr.FillRegion(br, rgn)
            End Using
        End Sub

        Shared Public Function CreateRoundedRectPath(ByVal r As Rectangle, ByVal radius As Integer) As GraphicsPath
            Dim path As GraphicsPath = New GraphicsPath()
            path.AddLine(r.Left + radius, r.Top, r.Left + r.Width - radius * 2, r.Top)
            path.AddArc(r.Left + r.Width - radius * 2, r.Top, radius * 2, radius * 2, 270, 90)
            path.AddLine(r.Left + r.Width, r.Top + radius, r.Left + r.Width, r.Top + r.Height - radius * 2)
            path.AddArc(r.Left + r.Width - radius * 2, r.Top + r.Height - radius * 2, radius * 2, radius * 2, 0, 90)
            path.AddLine(r.Left + r.Width - radius * 2, r.Top + r.Height, r.Left + radius, r.Top + r.Height)
            path.AddArc(r.Left, r.Top + r.Height - radius * 2, radius * 2, radius * 2, 90, 90)
            path.AddLine(r.Left, r.Top + r.Height - radius * 2, r.Left, r.Top + radius)
            path.AddArc(r.Left, r.Top, radius * 2, radius * 2, 180, 90)
            path.CloseFigure()
            Return path
        End Function
#End Region  ' #CustomDrawAppointmentBackground
    End Class
End Namespace
