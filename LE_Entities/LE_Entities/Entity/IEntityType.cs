namespace LE_Entities.Entity
{
    public interface IEntityType : IObject
    {

        void Execute(Entity entity,int id);
        void SetAction(ISystemAction[] groupActions);
        void SetName(string name);
    }
}