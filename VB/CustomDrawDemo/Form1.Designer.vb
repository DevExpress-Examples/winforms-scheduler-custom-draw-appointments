Imports Microsoft.VisualBasic
Imports System
Namespace CustomDrawDemo
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim timeRuler1 As New DevExpress.XtraScheduler.TimeRuler()
			Dim timeRuler2 As New DevExpress.XtraScheduler.TimeRuler()
			Me.schedulerControl1 = New DevExpress.XtraScheduler.SchedulerControl()
			Me.schedulerStorage1 = New DevExpress.XtraScheduler.SchedulerStorage(Me.components)
			Me.panelControl1 = New DevExpress.XtraEditors.PanelControl()
			Me.cbView = New DevExpress.XtraEditors.ImageComboBoxEdit()
			Me.lblView = New DevExpress.XtraEditors.LabelControl()
			Me.lblGroup = New DevExpress.XtraEditors.LabelControl()
			Me.rgrpGrouping = New DevExpress.XtraEditors.RadioGroup()
			Me.dateNavigator1 = New DevExpress.XtraScheduler.DateNavigator()
			CType(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.schedulerStorage1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.panelControl1.SuspendLayout()
			CType(Me.cbView.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.rgrpGrouping.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dateNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' schedulerControl1
			' 
			Me.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.schedulerControl1.Location = New System.Drawing.Point(0, 39)
			Me.schedulerControl1.Name = "schedulerControl1"
			Me.schedulerControl1.Size = New System.Drawing.Size(607, 469)
			Me.schedulerControl1.Start = New System.DateTime(2008, 12, 3, 0, 0, 0, 0)
			Me.schedulerControl1.Storage = Me.schedulerStorage1
			Me.schedulerControl1.TabIndex = 0
			Me.schedulerControl1.Text = "schedulerControl1"
			Me.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1)
			Me.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler2)
'			Me.schedulerControl1.ActiveViewChanged += New System.EventHandler(Me.schedulerControl_ActiveViewChanged);
'			Me.schedulerControl1.CustomDrawAppointment += New DevExpress.XtraScheduler.CustomDrawObjectEventHandler(Me.schedulerControl1_CustomDrawAppointment);
'			Me.schedulerControl1.CustomDrawAppointmentBackground += New DevExpress.XtraScheduler.CustomDrawObjectEventHandler(Me.schedulerControl1_CustomDrawAppointmentBackground);
			' 
			' panelControl1
			' 
			Me.panelControl1.Controls.Add(Me.cbView)
			Me.panelControl1.Controls.Add(Me.lblView)
			Me.panelControl1.Controls.Add(Me.lblGroup)
			Me.panelControl1.Controls.Add(Me.rgrpGrouping)
			Me.panelControl1.Dock = System.Windows.Forms.DockStyle.Top
			Me.panelControl1.Location = New System.Drawing.Point(0, 0)
			Me.panelControl1.Name = "panelControl1"
			Me.panelControl1.Size = New System.Drawing.Size(786, 39)
			Me.panelControl1.TabIndex = 1
			' 
			' cbView
			' 
			Me.cbView.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.cbView.EditValue = ""
			Me.cbView.Location = New System.Drawing.Point(52, 9)
			Me.cbView.Name = "cbView"
			Me.cbView.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.cbView.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() { New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Day View", DevExpress.XtraScheduler.SchedulerViewType.Day, -1), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Work Week View", DevExpress.XtraScheduler.SchedulerViewType.WorkWeek, -1), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Week View", DevExpress.XtraScheduler.SchedulerViewType.Week, -1), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Month View", DevExpress.XtraScheduler.SchedulerViewType.Month, -1), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Timeline View", DevExpress.XtraScheduler.SchedulerViewType.Timeline, -1)})
			Me.cbView.Size = New System.Drawing.Size(212, 20)
			Me.cbView.TabIndex = 10
'			Me.cbView.SelectedIndexChanged += New System.EventHandler(Me.cbView_SelectedIndexChanged);
			' 
			' lblView
			' 
			Me.lblView.Location = New System.Drawing.Point(16, 12)
			Me.lblView.Name = "lblView"
			Me.lblView.Size = New System.Drawing.Size(30, 13)
			Me.lblView.TabIndex = 9
			Me.lblView.Text = "Show:"
			' 
			' lblGroup
			' 
			Me.lblGroup.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.lblGroup.Location = New System.Drawing.Point(278, 12)
			Me.lblGroup.Name = "lblGroup"
			Me.lblGroup.Size = New System.Drawing.Size(48, 13)
			Me.lblGroup.TabIndex = 8
			Me.lblGroup.Text = "Group By:"
			' 
			' rgrpGrouping
			' 
			Me.rgrpGrouping.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.rgrpGrouping.EditValue = 1
			Me.rgrpGrouping.Location = New System.Drawing.Point(332, 5)
			Me.rgrpGrouping.Name = "rgrpGrouping"
			Me.rgrpGrouping.Properties.Columns = 3
			Me.rgrpGrouping.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() { New DevExpress.XtraEditors.Controls.RadioGroupItem(DevExpress.XtraScheduler.SchedulerGroupType.None, "None"), New DevExpress.XtraEditors.Controls.RadioGroupItem(DevExpress.XtraScheduler.SchedulerGroupType.Date, "Date"), New DevExpress.XtraEditors.Controls.RadioGroupItem(DevExpress.XtraScheduler.SchedulerGroupType.Resource, "Resource")})
			Me.rgrpGrouping.Size = New System.Drawing.Size(253, 24)
			Me.rgrpGrouping.TabIndex = 7
'			Me.rgrpGrouping.SelectedIndexChanged += New System.EventHandler(Me.rgrpGrouping_SelectedIndexChanged);
			' 
			' dateNavigator1
			' 
			Me.dateNavigator1.Dock = System.Windows.Forms.DockStyle.Right
			Me.dateNavigator1.Location = New System.Drawing.Point(607, 39)
			Me.dateNavigator1.Name = "dateNavigator1"
			Me.dateNavigator1.SchedulerControl = Me.schedulerControl1
			Me.dateNavigator1.Size = New System.Drawing.Size(179, 469)
			Me.dateNavigator1.TabIndex = 2
			Me.dateNavigator1.View = DevExpress.XtraEditors.Controls.DateEditCalendarViewType.MonthInfo
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(786, 508)
			Me.Controls.Add(Me.schedulerControl1)
			Me.Controls.Add(Me.dateNavigator1)
			Me.Controls.Add(Me.panelControl1)
			Me.Name = "Form1"
			Me.Text = "CustomDrawDemo"
			CType(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.schedulerStorage1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.panelControl1.ResumeLayout(False)
			Me.panelControl1.PerformLayout()
			CType(Me.cbView.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.rgrpGrouping.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dateNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private WithEvents schedulerControl1 As DevExpress.XtraScheduler.SchedulerControl
		Private schedulerStorage1 As DevExpress.XtraScheduler.SchedulerStorage
		Private panelControl1 As DevExpress.XtraEditors.PanelControl
		Private dateNavigator1 As DevExpress.XtraScheduler.DateNavigator
		Private WithEvents cbView As DevExpress.XtraEditors.ImageComboBoxEdit
		Private lblView As DevExpress.XtraEditors.LabelControl
		Private lblGroup As DevExpress.XtraEditors.LabelControl
		Private WithEvents rgrpGrouping As DevExpress.XtraEditors.RadioGroup
	End Class
End Namespace

