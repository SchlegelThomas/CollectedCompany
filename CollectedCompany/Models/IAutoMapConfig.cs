using AutoMapper;

namespace CollectedCompany.Models
{
    public interface IAutoMapConfig
    {
        void CreateMaps();
    }


    public abstract class AbstractBaseAutoMapEntity<T> : IAutoMapConfig
    {

        public virtual void CreateMaps()
        {
            Mapper.CreateMap(typeof(T), GetType());
            Mapper.CreateMap(GetType(), typeof(T));
        }
    }

    

}