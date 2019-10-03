angular.module("umbraco.resources").factory("propertySliderResources", function($http) {
    const myService = {};

    myService.getSalesTypes = function () {
        return $http.get("/App_Plugins/My_Awesome_PropertyEditor/resourcefiles/SalesTypes.json");
    };

    myService.getSearchParams = function() {
        return $http.get("/App_Plugins/My_Awesome_PropertyEditor/resourcefiles/SearchParams.json");
    };

    return myService;
});