using Mapster;
using Models.Mappers.Base.Interfaces;

namespace Models.Mappers.Base
{
    public class BaseMapper<Model, Entity> : IBaseMapper<Model, Entity>
    {
        public Model Map(Entity entity)
        {
            return entity.Adapt<Model>();
        }

        public Entity ToEntity(Model model)
        {
            return model.Adapt<Entity>();
        }
    }
}
