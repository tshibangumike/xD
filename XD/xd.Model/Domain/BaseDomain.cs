using System;
namespace xd.Model
{
    //public class BaseDomain
    //{
    //    public Guid Id { get; set; }
    //    public string Name { get; set; }
    //    public DateTime CreatedOn { get; set; }
    //    public Guid CreatedById { get; set; }
    //    public Guid ModifiedById { get; set; }
    //    public DateTime ModifiedOn { get; set; }
    //}
    public class BaseDomain<T>
    {
        public T Id { get; set; }
    }
}
