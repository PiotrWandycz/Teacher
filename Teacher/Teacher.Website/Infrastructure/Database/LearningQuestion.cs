namespace Teacher.Website.Infrastructure.Database
{
    public partial class LearningQuestion
    {
        public int Id { get; set; }
        public int LearningId { get; set; }
        public int QuestionId { get; set; }
        public bool WasAnswerCorrect { get; set; }

        public virtual Learning Learning { get; set; }
        public virtual Question Question { get; set; }
    }
}
