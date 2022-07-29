namespace StringExtensionsBspmLibrary
{
    public static partial class StringExtensions
    {
        ///// <summary />
        //public static (string Clauses, IEnumerable<string> SearchParts) ToLikeClause(this string searchText,
        //                                                                             IEnumerable<string> columnsName,
        //                                                                             string sqlParameterName = "@SearchText")
        //{
        //    // No search text => Act as if we went all results
        //    if (string.IsNullOrWhiteSpace(searchText))
        //    {
        //        return (Clauses: " (1 = 1) ", SearchParts: Enumerable.Empty<string>());
        //    }

        //    StringBuilder likeClausesSql = new StringBuilder();
        //    IEnumerable<string> searchParts = searchText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
        //                                     .Distinct();

        //    likeClausesSql.Append("(");
        //    for (int i = 0; i < searchParts.Count(); i++)
        //    {
        //        if (i != 0)
        //        {
        //            likeClausesSql.Append(" AND ");
        //        }

        //        likeClausesSql.Append("(");
        //        for (int j = 0; j < columnsName.Count(); j++)
        //        {
        //            if (j != 0)
        //            {
        //                likeClausesSql.Append(" OR ");
        //            }

        //            string columnName = columnsName.ElementAt(j);
        //            likeClausesSql.Append($"{columnName} LIKE {sqlParameterName}{i}");
        //        }
        //        likeClausesSql.Append(")");
        //    }
        //    likeClausesSql.Append(")");

        //    return (Clauses: likeClausesSql.ToString(), SearchParts: searchParts);
        //}

    }
}
