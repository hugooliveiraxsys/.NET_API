using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Mappers.Base.Interfaces
{
    public interface IBaseMapper<Model, Entity>
    {
        public Entity ToEntity(Model model);

        public Model Map(Entity entity);
    }
}
