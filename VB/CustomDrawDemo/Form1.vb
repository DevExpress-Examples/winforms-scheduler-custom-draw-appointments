Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
#Region "#usings"
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Drawing
Imports System.Drawing.Drawing2D
#End Region ' #usings

Namespace CustomDrawDemo
    Partial Public Class Form1
        Inherits Form

#Region "InitialDataConstants"
        Public Shared RandomInstance As New Random()
        Public Shared Users() As String = {"Peter Dolan", "Ryan Fischer", "Richard Fisher", "Tom Hamlett", "Mark Hamilton", "Steve Lee", "Jimmy Lewis", "Jeffrey W McClain", "Andrew Miller", "Dave Murrel", "Bert Parkins", "Mike Roller", "Ray Shipman", "Paul Bailey", "Brad Barnes", "Carl Lucas", "Jerry Campbell"}
#End Region

        Private colorArray() As Color = {Color.Red, Color.Green, Color.Blue, Color.Black}

        Public Sub New()
            InitializeComponent()
            FillResources(SchedulerDataStorage1, 5)
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
        Private Sub FillResources(ByVal storage As SchedulerDataStorage, ByVal count As Integer)
            Dim cnt As Integer = Math.Min(count, Users.Length)
            For i As Integer = 1 To cnt
                storage.Resources.Items.Add(storage.CreateResource(Guid.NewGuid(), Users(i - 1)))
            Next i
        End Sub
        Private Sub InitAppointments()
            Me.SchedulerDataStorage1.Appointments.Mappings.Start = "StartTime"
            Me.SchedulerDataStorage1.Appointments.Mappings.End = "EndTime"
            Me.SchedulerDataStorage1.Appointments.Mappings.Subject = "Subject"
            Me.SchedulerDataStorage1.Appointments.Mappings.AllDay = "AllDay"
            Me.SchedulerDataStorage1.Appointments.Mappings.Description = "Description"
            Me.SchedulerDataStorage1.Appointments.Mappings.Label = "Label"
            Me.SchedulerDataStorage1.Appointments.Mappings.Location = "Location"
            Me.SchedulerDataStorage1.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo"
            Me.SchedulerDataStorage1.Appointments.Mappings.ReminderInfo = "ReminderInfo"
            Me.SchedulerDataStorage1.Appointments.Mappings.ResourceId = "OwnerId"
            Me.SchedulerDataStorage1.Appointments.Mappings.Status = "Status"
            Me.SchedulerDataStorage1.Appointments.Mappings.Type = "EventType"

            Dim eventList As New CustomEventList()
            GenerateEvents(eventList)
            Me.SchedulerDataStorage1.Appointments.DataSource = eventList

        End Sub
        Private Sub GenerateEvents(ByVal eventList As CustomEventList)
            Dim count As Integer = SchedulerDataStorage1.Resources.Count
            For i As Integer = 0 To count - 1
                Dim resource As Resource = SchedulerDataStorage1.Resources(i)
                Dim subjPrefix As String = resource.Caption & "'s "
                eventList.Add(CreateEvent(eventList, subjPrefix & "meeting", resource.Id, 1, 5))
                eventList.Add(CreateEvent(eventList, subjPrefix & "travel", resource.Id, 4, 6))
                eventList.Add(CreateEvent(eventList, subjPrefix & "phone call", resource.Id, 5, 10))
            Next i
        End Sub
        Private Function CreateEvent(ByVal eventList As CustomEventList, ByVal subject As String, ByVal resourceId As Object, ByVal status As Integer, ByVal label As Integer) As CustomEvent
            Dim apt As New CustomEvent(eventList)
            apt.Subject = subject
            apt.OwnerId = resourceId
            Dim rnd As Random = RandomInstance
            Dim rangeInMinutes As Integer = 60 * 24
            apt.StartTime = Date.Today + TimeSpan.FromMinutes(rnd.Next(0, rangeInMinutes))
            apt.EndTime = apt.StartTime.Add(TimeSpan.FromMinutes(rnd.Next(0, rangeInMinutes \ 4)))
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
        Private Sub rgrpGrouping_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rgrpGrouping.SelectedIndexChanged
            schedulerControl1.GroupType = CType(rgrpGrouping.EditValue, SchedulerGroupType)
        End Sub

        Private Sub schedulerControl_ActiveViewChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles schedulerControl1.ActiveViewChanged
            cbView.EditValue = schedulerControl1.ActiveViewType
        End Sub

        Private Sub cbView_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbView.SelectedIndexChanged
            schedulerControl1.ActiveViewType = CType(cbView.EditValue, SchedulerViewType)
        End Sub
#End Region

#Region "#CustomDrawAppointment"
        Private Sub schedulerControl1_CustomDrawAppointment(ByVal sender As Object, ByVal e As CustomDrawObjectEventArgs) Handles schedulerControl1.CustomDrawAppointment
            Dim tlvi As TimeLineAppointmentViewInfo = TryCast(e.ObjectInfo, TimeLineAppointmentViewInfo)
            ' This code works only for the Timeline View.
            If tlvi IsNot Nothing Then
                Dim r As Rectangle = e.Bounds
                r.X += 3
                r.Y += 3
                Dim s() As String = tlvi.Appointment.Subject.Split(" "c)

                For i As Integer = 0 To s.Length - 1
                    e.Cache.DrawString(s(i), tlvi.Appearance.Font, New SolidBrush(colorArray(i)), r, StringFormat.GenericDefault)
                    Dim shift As SizeF = e.Graphics.MeasureString(s(i) & " ", tlvi.Appearance.Font)
                    r.X += CInt(shift.Width)
                Next i

                e.Handled = True
            End If
        End Sub
#End Region ' #CustomDrawAppointment

#Region "#CustomDrawAppointmentBackground"
        Private Sub schedulerControl1_CustomDrawAppointmentBackground(ByVal sender As Object, ByVal e As CustomDrawObjectEventArgs) Handles schedulerControl1.CustomDrawAppointmentBackground
            Dim aptViewInfo As DevExpress.XtraScheduler.Drawing.AppointmentViewInfo = TryCast(e.ObjectInfo, DevExpress.XtraScheduler.Drawing.AppointmentViewInfo)
            If aptViewInfo Is Nothing Then
                Return
            End If
            If aptViewInfo.Selected Then
                Dim r As Rectangle = e.Bounds
                Dim brRect As Brush = aptViewInfo.Status.GetBrush()
                e.Graphics.FillRectangle(brRect, r)
                e.Graphics.DrawRectangle(New Pen(Color.Blue, 2), r)
                e.Handled = True
            End If
        End Sub
#End Region ' #CustomDrawAppointmentBackground
    End Class
End Namespace