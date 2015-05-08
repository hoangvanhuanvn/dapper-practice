using System;

namespace DapperModel
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Tag()
        {
            Id = Guid.NewGuid();
        }
    }
}
