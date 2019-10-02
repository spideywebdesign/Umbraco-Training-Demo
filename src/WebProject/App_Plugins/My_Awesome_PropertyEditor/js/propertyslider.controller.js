angular.module("umbraco").controller("propertySlider.controller",
    function ($scope, propertySliderResources) {

        $scope.salesTypes = propertySliderResources.getSalesTypes();
        $scope.searchParams = propertySliderResources.getSearchParams();
    });