
function InitializeSearchBar () {
    $('#SearchBar').select2({ placeholder: "Select ingredients" });
}

function MasonryLayout() {
    $('#Cards').masonry('destroy');
    $('#Cards').masonry();
}