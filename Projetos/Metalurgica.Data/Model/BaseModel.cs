namespace Metalurgica.Data.Model
{
    public class BaseModel
    {
        public bool Fl_Ativo { get; set; }              
        public DateTime Dt_Criacao { get; set; }        
        public DateTime? Dt_Alteracao { get; set; }     
        public string? Ds_Alteracao { get; set; }
    }
}
