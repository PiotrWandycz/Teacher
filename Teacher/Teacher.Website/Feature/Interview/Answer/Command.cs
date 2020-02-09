using MediatR;

namespace Teacher.Website.Feature.Interview.Answer
{
    public class Command : IRequest
    {
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public bool WasAnswerCorrect { get; set; }
    }
}