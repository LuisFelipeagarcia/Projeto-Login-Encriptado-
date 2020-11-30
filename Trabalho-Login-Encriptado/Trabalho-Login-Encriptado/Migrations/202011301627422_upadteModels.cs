namespace Trabalho_Login_Encriptado.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upadteModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FornecedorModels", "Produto_Id", "dbo.ProdutoModels");
            DropIndex("dbo.FornecedorModels", new[] { "Produto_Id" });
            AddColumn("dbo.ProdutoModels", "FornecedorId", c => c.Int());
            CreateIndex("dbo.ProdutoModels", "FornecedorId");
            AddForeignKey("dbo.ProdutoModels", "FornecedorId", "dbo.FornecedorModels", "Id");
            DropColumn("dbo.FornecedorModels", "Produto_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FornecedorModels", "Produto_Id", c => c.Int());
            DropForeignKey("dbo.ProdutoModels", "FornecedorId", "dbo.FornecedorModels");
            DropIndex("dbo.ProdutoModels", new[] { "FornecedorId" });
            DropColumn("dbo.ProdutoModels", "FornecedorId");
            CreateIndex("dbo.FornecedorModels", "Produto_Id");
            AddForeignKey("dbo.FornecedorModels", "Produto_Id", "dbo.ProdutoModels", "Id");
        }
    }
}
