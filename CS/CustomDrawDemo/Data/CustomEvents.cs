using System;
using System.Collections;
using System.ComponentModel;

namespace CustomDrawDemo{

    public class CustomEvent : IEditableObject {
        DateTime fStart;
        DateTime fEnd;
        string fSubject;
        int fStatus;
        string fDescription;
        long fLabel;
        string fLocation;
        bool fAllday;
        int fEventType;
        string fRecurrenceInfo;
        string fReminderInfo;
        object fOwnerId;

        CustomEventList events;
        bool committed = false;

        public CustomEvent(CustomEventList events) {
            this.events = events;
        }

        private void OnListChanged() {
            int index = events.IndexOf(this);
            events.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, index));
        }

        public DateTime StartTime { get { return fStart; } set { fStart = value; } }
        public DateTime EndTime { get { return fEnd; } set { fEnd = value; } }
        public string Subject { get { return fSubject; } set { fSubject = value; } }
        public int Status { get { return fStatus; } set { fStatus = value; } }
        public string Description { get { return fDescription; } set { fDescription = value; } }
        public long Label { get { return fLabel; } set { fLabel = value; } }
        public string Location { get { return fLocation; } set { fLocation = value; } }
        public bool AllDay { get { return fAllday; } set { fAllday = value; } }
        public int EventType { get { return fEventType; } set { fEventType = value; } }
        public string RecurrenceInfo { get { return fRecurrenceInfo; } set { fRecurrenceInfo = value; } }
        public string ReminderInfo { get { return fReminderInfo; } set { fReminderInfo = value; } }
        public object OwnerId { get { return fOwnerId; } set { fOwnerId = value; } }

        public void BeginEdit() {
        }
        public void CancelEdit() {
            if (!committed) {
                ((IList)events).Remove(this);
            }
        }
        public void EndEdit() {
            committed = true;
        }
    }

    public class CustomEventList : CollectionBase, IBindingList {
        public CustomEvent this[int idx] { get { return (CustomEvent)base.List[idx]; } }

        public new void Clear() {
            base.Clear();
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }
        public void Add(CustomEvent appointment) {
            base.List.Add(appointment);
        }
        public int IndexOf(CustomEvent appointment) {
            return List.IndexOf(appointment);
        }
        public object AddNew() {
            CustomEvent app = new CustomEvent(this);
            List.Add(app);
            return app;
        }
        public bool AllowEdit { get { return true; } }
        public bool AllowNew { get { return true; } }
        public bool AllowRemove { get { return true; } }

        private ListChangedEventHandler listChangedHandler;
        public event ListChangedEventHandler ListChanged {
            add { listChangedHandler += value; }
            remove { listChangedHandler -= value; }
        }
        internal void OnListChanged(ListChangedEventArgs args) {
            if (listChangedHandler != null) {
                listChangedHandler(this, args);
            }
        }
        protected override void OnRemoveComplete(int index, object value) {
            OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
        }
        protected override void OnInsertComplete(int index, object value) {
            OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index));
        }

        public void AddIndex(PropertyDescriptor pd) { throw new NotSupportedException(); }
        public void ApplySort(PropertyDescriptor pd, ListSortDirection dir) { throw new NotSupportedException(); }
        public int Find(PropertyDescriptor property, object key) { throw new NotSupportedException(); }
        public bool IsSorted { get { return false; } }
        public void RemoveIndex(PropertyDescriptor pd) { throw new NotSupportedException(); }
        public void RemoveSort() { throw new NotSupportedException(); }
        public ListSortDirection SortDirection { get { throw new NotSupportedException(); } }
        public PropertyDescriptor SortProperty { get { throw new NotSupportedException(); } }
        public bool SupportsChangeNotification { get { return true; } }
        public bool SupportsSearching { get { return false; } }
        public bool SupportsSorting { get { return false; } }
    }
}
