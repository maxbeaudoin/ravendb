namespace Raven.Studio.Features.JsonEditor {
    using ActiproSoftware.Text.Parsing;
    using ActiproSoftware.Text.Parsing.Implementation;
    using System;
    
    
    /// <summary>
    /// Represents a json string.
    /// </summary>
    /// <remarks>
    /// This type was generated by the Actipro Language Designer tool v12.1.561.0 (http://www.actiprosoftware.com).
    /// </remarks>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("LanguageDesigner", "12.1.561.0")]
    public partial class JsonStringNode : AstNodeBase {
        
        /// <summary>
        /// Gets the value.
        /// </summary>
        private String valueValue;
        
        /// <summary>
        /// Gets the An integer value that identifies the type of AST node.
        /// </summary>
        /// <value>The An integer value that identifies the type of AST node.</value>
        public override Int32 Id {
            get {
                return JsonAstNodeId.JsonStringNode;
            }
        }
        
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public new String Value {
            get {
                return this.valueValue;
            }
            set {
                this.valueValue = value;
            }
        }
    }
}