namespace LE_Entities.Entity
{
    interface IEntityType : IObject
    {

        void Execute(Entity entity,int id);
        void Execute(EntityBlock entityBlock);
        void SetAction(ISystemAction[] groupActions);
        void SetName(string name);
    }
}