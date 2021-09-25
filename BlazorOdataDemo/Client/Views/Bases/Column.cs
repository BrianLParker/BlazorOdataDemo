using System.Reflection;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlazorOdataDemo.Client.Views.Bases;

public class Column
{
    private readonly PropertyInfo propertyInfo;

    public Column(PropertyInfo propertyInfo)
    {
        this.propertyInfo = propertyInfo;
        HeadContent = column => builder =>
        {
            var textContent = column.propertyInfo.Name;
            var isHeadCssNull = string.IsNullOrWhiteSpace(HeadCss);
            var isHeadStyleNull = string.IsNullOrWhiteSpace(HeadStyle);
            if (string.IsNullOrWhiteSpace(HeadCss) && string.IsNullOrWhiteSpace(HeadStyle))
            {
                BuildDivWithStringContent(builder, textContent);
            }
            else if (string.IsNullOrWhiteSpace(HeadStyle))
            {
                BuildDivWithStringContentClass(builder, textContent, HeadCss);
            }
            else if (string.IsNullOrWhiteSpace(HeadCss))
            {
                BuildDivWithStringContentStyle(builder, textContent, HeadStyle);
            }
            else
            {
                BuildDivWithStringContent(builder, textContent, HeadCss, HeadStyle);
            }

        };
    }

    public string HeadCss { get; set; }
    public string HeadStyle { get; set; }

    private static void BuildDivWithStringContent(RenderTreeBuilder builder, string textContent)
    {
        builder.OpenElement(sequence: 1, elementName: "div");
        builder.AddContent(sequence: 2, textContent);
        builder.CloseElement();
    }
    private static void BuildDivWithStringContentClass(RenderTreeBuilder builder, string textContent, string cssClass)
    {
        builder.OpenElement(sequence: 1, elementName: "div");
        builder.AddAttribute(sequence: 2, name: "class", cssClass);
        builder.AddContent(sequence: 3, textContent);
        builder.CloseElement();
    }
    private static void BuildDivWithStringContentStyle(RenderTreeBuilder builder, string textContent, string style)
    {
        builder.OpenElement(sequence: 1, elementName: "div");
        builder.AddAttribute(sequence: 2, name: "style", style);
        builder.AddContent(sequence: 3, textContent);
        builder.CloseElement();
    }
    private static void BuildDivWithStringContent(RenderTreeBuilder builder, string textContent, string cssClass, string style)
    {
        builder.OpenElement(sequence: 1, elementName: "div");
        builder.AddAttribute(sequence: 2, name: "class", cssClass);
        builder.AddAttribute(sequence: 3, name: "style", style);
        builder.AddContent(sequence: 4, textContent);
        builder.CloseElement();
    }

    public ColumnWidth Width { get; set; }
    public RenderFragment<Column> HeadContent { get; set; }
}