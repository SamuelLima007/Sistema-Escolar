namespace ProjetoNotas.Domain.Models
{
    public class Score
    {
        public int ScoreId { get; set; }
        public decimal Value { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
