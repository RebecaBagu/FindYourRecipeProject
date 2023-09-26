
function InitializeSearchBar () {
    $('#SearchBar').select2({ placeholder: "Select ingredients" });
}

function GetSearchBarValues() {
    var results = [];
    var sel = $('#SearchBar')[0];
    for (var i = 0; i < sel.options.length; i++) {
        if (sel.options[i].selected) {
            results[results.length] = parseInt(sel.options[i].value);
        }
    }
    return results;
};


