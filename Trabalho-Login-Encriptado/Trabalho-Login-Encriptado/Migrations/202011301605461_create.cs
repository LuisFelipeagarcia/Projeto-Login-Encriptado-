namespace Trabalho_Login_Encriptado.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FornecedorModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Email = c.String(),
                        Telefone = c.String(),
                        CNPJ = c.String(nullable: false),
                        Produto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProdutoModels", t => t.Produto_Id)
                .Index(t => t.Produto_Id);
            
            CreateTable(
                "dbo.ProdutoModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false),
                        Qtde_Estoque = c.Int(nullable: false),
                        Custo = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UsuarioModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Senha = c.String(nullable: false, maxLength: 255),
                        ConfirmaSenha = c.String(),
                        Nivel = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FornecedorModels", "Produto_Id", "dbo.ProdutoModels");
            DropIndex("dbo.FornecedorModels", new[] { "Produto_Id" });
            DropTable("dbo.UsuarioModels");
            DropTable("dbo.ProdutoModels");
            DropTable("dbo.FornecedorModels");
        }
    }
}
