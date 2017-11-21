public class CustomerViewModel {
        //[Key]

        public int CustomerID { get; set; }
        public string Username { get; set; }
        public string Userlastname{ get; set; }
        //[MaxLength(50)]
        public string Email_adress{ get; set;}
        //[MaxLength(24)]
        public string Password{ get; set;}
}