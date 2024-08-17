namespace Compiler
{
    public class AST
    {
        public List<ASTNode> Nodes{get;set;}

        public AST()
        {
            Nodes = new List<ASTNode>();
        }
    }
    public abstract class ASTNode
    {
        public int Position {get; set;}
        public abstract bool CheckSemantic();
        public abstract void Evaluate();
        
    }

}
