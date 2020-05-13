using System.Data.Entity;

namespace KanbanSystemDAL.Model
{
    public class KanbanSystemContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<CardList> CardLists { get; set; }
        public virtual DbSet<LabelColor> LabelColors { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CardActivity> CardActivities { get; set; }
        public virtual DbSet<Board> Boards { get; set; }
        public KanbanSystemContext() : base("name=KanbanSystemContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<KanbanSystemContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
