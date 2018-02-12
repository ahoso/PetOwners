/*!
 * function.js
 *
 * Custom functions called from PetOwners MVC Web Application
 *
 * Copyright @ Akiko Hosonuma 2018
 * Date: 2018-02-11
 */


/**
 * Display Cat List - Grouped by Owner's gender, sort by alphabetical order
 * @param {any} listOwnerGenders list of genders of owners
 * @param {any} listAll list of all cat with owner's gender and cat's name
 */
function DisplayCatList(listOwnerGenders, listAll)
{
    // Loop through by owner's gender
    $.each(listOwnerGenders, function (idx, gender) {

        // Set list header with owner's gender
        $("#catList").append("<h4>" + gender + "</h4>");

        // Filter list of Cat's name by owner's gender
        var listCats = listAll.filter(function (cat) {
            return cat.OwnerGender == gender;
        });

        // sort array by cat name in alphabetical order
        listCats.sort(SortByName);
    
        // loop through appending cat's name to the list 
        var catNames = "<ul>";
        $.each(listCats, function (idx, cat) {
            catNames += "<li>" + cat.Name + "</li>";
        });
        catNames += "</ul>";
        $("#catList").append(catNames);
       
    })
}

/**
 * Sorting list by Name in alphabetical order
 * @param {any} x 
 * @param {any} y
 */
function SortByName(x, y) {
    return ((x.Name == y.Name) ? 0 : ((x.Name > y.Name) ? 1 : -1));
}

