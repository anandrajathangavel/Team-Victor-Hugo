namespace OnlineBooking.Model
{
    using System;

    public class Notification
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public virtual int UersId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
