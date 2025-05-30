namespace APIDB.Model
{
    public class Lekcja
    {
        public int id { get; set; }
        public virtual Sala sala { get; set; }
        public virtual Nauczyciel nauczyciel{ get; set; }
        public virtual Przedmiot przedmiot { get; set; }
        public virtual Klasa klasa { get; set; }
        public int godzinaLekcyjna { get; set; }
        public bool zastepstwo { get; set; }
    }
}
