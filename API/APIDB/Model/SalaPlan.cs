namespace APIDB.Model
{
    public class SalaPlan
    {
        public Sala sala { get; set; }
        public List<Lekcja> plan { get; set; }
    }
}
