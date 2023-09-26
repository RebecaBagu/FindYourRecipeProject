function InitializeSearchBar() {
    $('#SearchBar').select2({ placeholder: "Select ingredients" });
}

//https://learn.microsoft.com/en-us/answers/questions/1188191/how-to-implement-(select-multiple)-in-blazor-serve
function GetSearchBarValues() {
    var searchBar = $('#SearchBar')[0];
    var results = [];
    for (var i = 0; i < searchBar.options.length; i++) {
        if (searchBar.options[i].selected) {
            results[results.length] = parseInt(searchBar.options[i].value);
        }
    }
    return results;
};