using System;

namespace Dto
{
    public abstract class DtoBase
    {
        public int Id { get; set; }
    }

    public abstract class PrudentialFirstDtoBase
    {
        public Guid Id { get; set; }
    }
}
