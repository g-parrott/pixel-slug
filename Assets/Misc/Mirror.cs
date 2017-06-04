public interface IMirror<FromT, ToT>
{
    FromT Middle(FromT real, ToT projection);

    ToT Projection(FromT real);

    FromT Reflection(ToT projection);
}
