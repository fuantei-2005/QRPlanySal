namespace APIDB.Model
{
    public class Sala
    {
        public int id { get; set; }
        public virtual Nauczyciel nauczyciel { get; set; }
        public string pietro { get; set; }
        public string numer { get; set; }
        public string dodatkoweInfo { get; set; }
    }
}
