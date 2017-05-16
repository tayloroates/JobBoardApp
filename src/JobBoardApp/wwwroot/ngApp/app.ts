namespace JobBoardApp {

    angular.module('JobBoardApp', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: JobBoardApp.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('details', {
                url: '/details/:id',
                templateUrl: '/ngApp/views/details.html',
                controller: JobBoardApp.Controllers.JobDetailsController,
                controllerAs: 'controller'
            })
            .state('postJobs', {
                url: '/postJobs',
                templateUrl: '/ngApp/views/postJobs.html',
                controller: JobBoardApp.Controllers.PostJobController,
                controllerAs: 'controller'
            })
            .state('secret', {
                url: '/secret',
                templateUrl: '/ngApp/views/secret.html',
                controller: JobBoardApp.Controllers.SecretController,
                controllerAs: 'controller',
                data: {
                    requiresAuthentication: true,
                }
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: JobBoardApp.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('jobListings', {
                url: '/jobListings',
                templateUrl: '/ngApp/views/jobListings.html',
                controller: JobBoardApp.Controllers.JobController,
                controllerAs: 'controller'
            })
            .state('deleteJob', {
                url: '/deleteJob/:id',
                templateUrl: '/ngApp/views/deleteJob.html',
                controller: JobBoardApp.Controllers.JobDeleteController,
                controllerAs: 'controller'
            })
            .state('resume', {
                url: '/resume',
                templateUrl: '/ngApp/views/resume.html',
                controller: JobBoardApp.Controllers.ResumeController,
                controllerAs: 'controller'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: JobBoardApp.Controllers.RegisterController,
                controllerAs: 'controller'
            })
            .state('externalRegister', {
                url: '/externalRegister',
                templateUrl: '/ngApp/views/externalRegister.html',
                controller: JobBoardApp.Controllers.ExternalRegisterController,
                controllerAs: 'controller'
            }) 
            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/views/about.html',
                controller: JobBoardApp.Controllers.AboutController,
                controllerAs: 'controller'
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });

    
    angular.module('JobBoardApp').factory('authInterceptor', (
        $q: ng.IQService,
        $window: ng.IWindowService,
        $location: ng.ILocationService
    ) =>
        ({
            request: function (config) {
                config.headers = config.headers || {};
                config.headers['X-Requested-With'] = 'XMLHttpRequest';
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401 || rejection.status === 403) {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        })
    );

    angular.module('JobBoardApp').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });

    angular.module('JobBoardApp').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });
    angular.module('JobBoardApp').run((
        $rootScope: ng.IRootScopeService,
        $state: ng.ui.IStateService,
        accountService: JobBoardApp.Services.AccountService
    ) => {
        $rootScope.$on('$stateChangeStart', (e, to) => {
            // protect non-public views
            if (to.data && to.data.requiresAuthentication) {
                if (!accountService.isLoggedIn()) {
                    e.preventDefault();
                    $state.go('login');
                }
            }
        });
    });




}
