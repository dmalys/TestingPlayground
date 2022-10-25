using System.Threading.Tasks;

namespace TestingProj.Repository
{
    public interface IFinishedWorkRepository
    {
        public void NotifyFinishedWorkAsync(int currentUsersCount); 
    }
}