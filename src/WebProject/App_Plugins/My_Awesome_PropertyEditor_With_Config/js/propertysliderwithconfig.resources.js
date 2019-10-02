angular.module("umbraco.resources").factory("propertySliderWithConfigResources", function($http) {
    let myService = {};

    myService.getSalesTypes = function () {
        return $http.get("/App_Plugins/My_Awesome_PropertyEditor_With_Config/resourcefiles/SalesTypes.json");
    };

    myService.getSearchParams = function() {
        return $http.get("/App_Plugins/My_Awesome_PropertyEditor_With_Config/resourcefiles/SearchParams.json");
    };

    return myService;
});