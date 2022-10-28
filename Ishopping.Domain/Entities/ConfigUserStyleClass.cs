using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using System;

namespace Ishopping.Domain.Entities
{
    public class ConfigUserStyleClass 
    {
        public Guid Id { get;  set; }
        public string IdUser { get;  set; }
        public int SiteNumber { get;  set; }
        public string ClassFor { get;  set; }
        public string ClassName { get;  set; }
        public int ClassType { get; set; }       

        // default
        public bool UserDefault { get;  set; }
        public string DefaultFontSize { get;  set; }
        public string DefaultFontFamily { get;  set; }
        public string DefaultFontWeight { get;  set; }
        public string DefaultFontStyle { get;  set; }
        public string DefaultLetterSpacing { get; set; }
        public string DefaultLineHeight { get; set; }
        public string DefaultColor { get;  set; }
        public string DefaultBackgroundColor { get;  set; }
        public string DefaultBorder { get;  set; }
        public string DefaultBoxShadow { get;  set; }
        public string DefaultBorderRadius { get;  set; }
        public string DefaultTextShadow { get;  set; }
        public string DefaultPadding { get;  set; }
        public string DefaultMove { get;  set; }

        public string DefaultTransformRotate { get; set; }
        public string DefaultTransformSkew { get; set; }
        public string DefaultTransformScaleX { get; set; }
        public string DefaultTransformScaleY { get; set; }
        public string DefaultTransformTranslateX { get; set; }
        public string DefaultTransformTranslateY { get; set; }
        public string DefaultTransitionProperty { get; set; }
        public string DefaultTransitionFunction { get; set; }
        public string DefaultTransitionDelay { get; set; }
        public bool DefaultAlterText { get; set; }
        public bool DefaultAlterSize { get;  set; }
        public bool DefaultAlterBorder { get;  set; }
        public bool DefaultAlterTextShadow { get;  set; }
        public bool DefaultAlterBoxShadow { get;  set; }
        public bool DefaultUserTransform { get; set; }
        public bool DefaultUserTransition { get; set; }

        // mouse hover
        public bool UserHover { get;  set; }
        public string HoverFontSize { get;  set; }
        public string HoverFontFamily { get;  set; }
        public string HoverFontWeight { get;  set; }
        public string HoverFontStyle { get;  set; }
        public string HoverLetterSpacing { get; set; }
        public string HoverLineHeight { get; set; }
        public string HoverColor { get;  set; }
        public string HoverBackgroundColor { get;  set; }
        public string HoverBorder { get;  set; }
        public string HoverBoxShadow { get;  set; }
        public string HoverBorderRadius { get;  set; }
        public string HoverTextShadow { get;  set; }
        public string HoverPadding { get;  set; }
        public string HoverMove { get;  set; }
        public string HoverTransformRotate { get; set; }
        public string HoverTransformSkew { get; set; }
        public string HoverTransformScaleX { get; set; }
        public string HoverTransformScaleY { get; set; }
        public string HoverTransformTranslateX { get; set; }
        public string HoverTransformTranslateY { get; set; }
        public bool HoverAlterText { get; set; }
        public bool HoverAlterSize { get;  set; }
        public bool HoverAlterBorder { get;  set; }
        public bool HoverAlterTextShadow { get;  set; }
        public bool HoverAlterBoxShadow { get;  set; }
        public bool HoverUserTransform { get; set; }

        // active
        public bool UserActive { get;  set; }
        public string ActiveFontSize { get;  set; }
        public string ActiveFontFamily { get;  set; }
        public string ActiveFontWeight { get;  set; }
        public string ActiveFontStyle { get;  set; }
        public string ActiveLetterSpacing { get; set; }
        public string ActiveLineHeight { get; set; }
        public string ActiveColor { get;  set; }
        public string ActiveBackgroundColor { get;  set; }
        public string ActiveBorder { get;  set; }
        public string ActiveBoxShadow { get;  set; }
        public string ActiveBorderRadius { get;  set; }
        public string ActiveTextShadow { get;  set; }
        public string ActivePadding { get;  set; }
        public string ActiveMove { get;  set; }
        public string ActiveTransformRotate { get; set; }
        public string ActiveTransformSkew { get; set; }
        public string ActiveTransformScaleX { get; set; }
        public string ActiveTransformScaleY { get; set; }
        public string ActiveTransformTranslateX { get; set; }
        public string ActiveTransformTranslateY { get; set; }
        public bool ActiveAlterText { get; set; }
        public bool ActiveAlterSize { get;  set; }
        public bool ActiveAlterBorder { get;  set; }
        public bool ActiveAlterTextShadow { get;  set; }
        public bool ActiveAlterBoxShadow { get;  set; }
        public bool ActiveUserTransform { get; set; }

        // span
        public bool UserSpan { get;  set; }
        public string SpanFontSize { get;  set; }
        public string SpanFontFamily { get;  set; }
        public string SpanFontWeight { get;  set; }
        public string SpanFontStyle { get;  set; }
        public string SpanLetterSpacing { get; set; }
        public string SpanLineHeight { get; set; }
        public string SpanColor { get;  set; }
        public string SpanBackgroundColor { get;  set; }
        public string SpanBorder { get;  set; }
        public string SpanBoxShadow { get;  set; }
        public string SpanBorderRadius { get;  set; }
        public string SpanTextShadow { get;  set; }
        public string SpanPadding { get;  set; }
        public string SpanMove { get;  set; }
        public string SpanTransformRotate { get; set; }
        public string SpanTransformSkew { get; set; }
        public string SpanTransformScaleX { get; set; }
        public string SpanTransformScaleY { get; set; }
        public string SpanTransformTranslateX { get; set; }
        public string SpanTransformTranslateY { get; set; }
        public bool SpanAlterText { get; set; }
        public bool SpanAlterSize { get;  set; }
        public bool SpanAlterBorder { get;  set; }
        public bool SpanAlterTextShadow { get;  set; }
        public bool SpanAlterBoxShadow { get;  set; }
        public bool SpanUserTransform { get; set; }
                      
    }
}
