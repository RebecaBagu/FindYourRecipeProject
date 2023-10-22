
function InitializeSearchBar () {
    $('#SearchBar').select2({ placeholder: "Select ingredients" });
}


function GetSearchBarValues() {
    var e = document.getElementById("SearchBar");

    return getSelectValues(e);
}

function getSelectValues(select) {
    var result = [];
    var options = select && select.options;
    var opt;

    for (var i = 0, iLen = options.length; i < iLen; i++) {
        opt = options[i];

        if (opt.selected) {
            result.push(opt.value || opt.text);
        }
    }
    return result;
}

function MasonryLayout() {
    $('#Cards').masonry('destroy');
    $('#Cards').masonry();
}
