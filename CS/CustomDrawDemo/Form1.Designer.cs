namespace CustomDrawDemo {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            this.schedulerControl1 = new DevExpress.XtraScheduler.SchedulerControl();
            this.schedulerDataStorage1 = new DevExpress.XtraScheduler.SchedulerDataStorage(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cbView = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.lblView = new DevExpress.XtraEditors.LabelControl();
            this.lblGroup = new DevExpress.XtraEditors.LabelControl();
            this.rgrpGrouping = new DevExpress.XtraEditors.RadioGroup();
            this.dateNavigator1 = new DevExpress.XtraScheduler.DateNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerDataStorage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbView.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgrpGrouping.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // schedulerControl1
            // 
            this.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulerControl1.Location = new System.Drawing.Point(0, 39);
            this.schedulerControl1.Name = "schedulerControl1";
            this.schedulerControl1.Size = new System.Drawing.Size(581, 469);
            this.schedulerControl1.Start = new System.DateTime(2008, 12, 3, 0, 0, 0, 0);
            this.schedulerControl1.DataStorage = this.schedulerDataStorage1;
            this.schedulerControl1.TabIndex = 0;
            this.schedulerControl1.Text = "schedulerControl1";
            this.schedulerControl1.Views.DayView.AllDayAreaScrollBarVisible = false;
            this.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schedulerControl1.Views.FullWeekView.AllDayAreaScrollBarVisible = false;
            this.schedulerControl1.Views.TimelineView.TimelineScrollBarVisible = false;
            this.schedulerControl1.Views.WorkWeekView.AllDayAreaScrollBarVisible = false;
            this.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler2);
            this.schedulerControl1.ActiveViewChanged += new System.EventHandler(this.schedulerControl_ActiveViewChanged);
            this.schedulerControl1.CustomDrawAppointmentBackground += new DevExpress.XtraScheduler.CustomDrawObjectEventHandler(this.schedulerControl1_CustomDrawAppointmentBackground);
            this.schedulerControl1.InitAppointmentDisplayText += schedulerControl1_InitAppointmentDisplayText;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cbView);
            this.panelControl1.Controls.Add(this.lblView);
            this.panelControl1.Controls.Add(this.lblGroup);
            this.panelControl1.Controls.Add(this.rgrpGrouping);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(786, 39);
            this.panelControl1.TabIndex = 1;
            // 
            // cbView
            // 
            this.cbView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbView.EditValue = "";
            this.cbView.Location = new System.Drawing.Point(52, 9);
            this.cbView.Name = "cbView";
            this.cbView.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbView.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Day View", DevExpress.XtraScheduler.SchedulerViewType.Day, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Work Week View", DevExpress.XtraScheduler.SchedulerViewType.WorkWeek, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Week View", DevExpress.XtraScheduler.SchedulerViewType.Week, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Month View", DevExpress.XtraScheduler.SchedulerViewType.Month, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Timeline View", DevExpress.XtraScheduler.SchedulerViewType.Timeline, -1)});
            this.cbView.Size = new System.Drawing.Size(212, 20);
            this.cbView.TabIndex = 10;
            this.cbView.SelectedIndexChanged += new System.EventHandler(this.cbView_SelectedIndexChanged);
            // 
            // lblView
            // 
            this.lblView.Location = new System.Drawing.Point(16, 12);
            this.lblView.Name = "lblView";
            this.lblView.Size = new System.Drawing.Size(30, 13);
            this.lblView.TabIndex = 9;
            this.lblView.Text = "Show:";
            // 
            // lblGroup
            // 
            this.lblGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGroup.Location = new System.Drawing.Point(278, 12);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(48, 13);
            this.lblGroup.TabIndex = 8;
            this.lblGroup.Text = "Group By:";
            // 
            // rgrpGrouping
            // 
            this.rgrpGrouping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rgrpGrouping.EditValue = 1;
            this.rgrpGrouping.Location = new System.Drawing.Point(332, 5);
            this.rgrpGrouping.Name = "rgrpGrouping";
            this.rgrpGrouping.Properties.Columns = 3;
            this.rgrpGrouping.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(DevExpress.XtraScheduler.SchedulerGroupType.None, "None"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(DevExpress.XtraScheduler.SchedulerGroupType.Date, "Date"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(DevExpress.XtraScheduler.SchedulerGroupType.Resource, "Resource")});
            this.rgrpGrouping.Size = new System.Drawing.Size(253, 24);
            this.rgrpGrouping.TabIndex = 7;
            this.rgrpGrouping.SelectedIndexChanged += new System.EventHandler(this.rgrpGrouping_SelectedIndexChanged);
            // 
            // dateNavigator1
            // 
            this.dateNavigator1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNavigator1.CellPadding = new System.Windows.Forms.Padding(2);
            this.dateNavigator1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dateNavigator1.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.dateNavigator1.Location = new System.Drawing.Point(581, 39);
            this.dateNavigator1.Name = "dateNavigator1";
            this.dateNavigator1.SchedulerControl = this.schedulerControl1;
            this.dateNavigator1.Size = new System.Drawing.Size(205, 469);
            this.dateNavigator1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 508);
            this.Controls.Add(this.schedulerControl1);
            this.Controls.Add(this.dateNavigator1);
            this.Controls.Add(this.panelControl1);
            this.Name = "Form1";
            this.Text = "CustomDrawDemo";
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerDataStorage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbView.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgrpGrouping.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DevExpress.XtraScheduler.SchedulerControl schedulerControl1;
        private DevExpress.XtraScheduler.SchedulerDataStorage schedulerDataStorage1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraScheduler.DateNavigator dateNavigator1;
        private DevExpress.XtraEditors.ImageComboBoxEdit cbView;
        private DevExpress.XtraEditors.LabelControl lblView;
        private DevExpress.XtraEditors.LabelControl lblGroup;
        private DevExpress.XtraEditors.RadioGroup rgrpGrouping;
    }
}

