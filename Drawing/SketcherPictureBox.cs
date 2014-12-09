using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sketcher.Drawing.Expressions;
using Sketcher.Udfs;
using System.ComponentModel;
using Antlr.Runtime;
using System.Drawing;

namespace Sketcher.Drawing
{
    public class SketcherPictureBox : PictureBox
    {
        private Expression curExpr;

        [DefaultValue(-30)]
        public int EvaluationBegin { get; set; }
        [DefaultValue(30)]
        public int EvaluationEnd { get; set; }
        [DefaultValue(1)]
        public int EvaluationStep { get; set; }

        public SketcherPictureBox()
        {
            EvaluationBegin = -30;
            EvaluationEnd = 30;
            EvaluationStep = 1;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            if (curExpr == null) return;
            var g = pe.Graphics;
            var points = new PointF[(int)Math.Ceiling((double)(
                Math.Abs(EvaluationEnd) + Math.Abs(EvaluationBegin) + 1) / Math.Abs(EvaluationStep))];
            int idx = 0;
            var xVar = Sketcher.Udfs.Runtime.RuntimeEnvironment.Instance.GlobalVariables.Find(i => i.Name == "x");
            for (int x = EvaluationBegin; x <= EvaluationEnd; x += EvaluationStep, ++idx)
            {
                points[idx] = new PointF((float)(xVar.Value = x), (float)curExpr.Execute());
            }
            g.DrawCurve(Pens.Red, points);
        }

        public Expression ParseExpression(string expr)
        {
            expressionParser parser = new expressionParser(
                new CommonTokenStream(
                    new expressionLexer(
                        new ANTLRStringStream(expr))));
            var ret = parser.compileUnit();
            if (parser.NumberOfSyntaxErrors == 0)
                return new Expression(ParsingHelper.BuildExpression(ret.Tree));
            else return new Expression(parser.NumberOfSyntaxErrors);
        }

        public void Draw(Expression expr)
        {
            this.curExpr = expr;
            Invalidate();
        }
    }
}
