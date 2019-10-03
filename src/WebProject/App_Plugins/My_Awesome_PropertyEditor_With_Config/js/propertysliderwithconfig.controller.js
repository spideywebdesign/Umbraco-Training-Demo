angular.module("umbraco").controller("propertySliderWithConfig.controller",
    function ($scope, propertySliderWithConfigResources) {
        //console.log("$scope.model.value", $scope.model.value);
        //console.log("$scope.model.config", $scope.model.config);

        if ($scope.model.value === null || $scope.model.value === "") {
            const defaultModelValue = {
                carouselHeader: $scope.model.config.defaultCarouselHeader,
                speed: $scope.model.config.defaultSpeed ? Number($scope.model.config.defaultSpeed) : 300,
                animate: $scope.model.config.defaultAnimate === "1",
                showArrows: $scope.model.config.defaultShowArrows === "1",
                residentialPropertyCount: Number($scope.model.config.defaultResidentialPropertyCount),
                lettingsPropertyCount: Number($scope.model.config.defaultLettingsPropertyCount),
                buttonLinkText: $scope.model.config.defaultButtonLinkText,
                showForCurrentBrandOnly: $scope.model.config.defaultShowForCurrentBrandOnly === "1"
            };

            //console.log("defaultModelValue", defaultModelValue);

            $scope.model.value = defaultModelValue;

            //console.log("Freshly assigned $scope.model.value", $scope.model.value);
        }

        $scope.salesTypes = propertySliderWithConfigResources.getSalesTypes();
        $scope.searchParams = propertySliderWithConfigResources.getSearchParams();
    });