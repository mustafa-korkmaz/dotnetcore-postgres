
namespace Dto
{
    public abstract class DtoBase : IDto<int>
    {
        public int Id { get; set; }
    }

    public interface IDto<TKey>
    {
        TKey Id { get; set; }
    }
}
