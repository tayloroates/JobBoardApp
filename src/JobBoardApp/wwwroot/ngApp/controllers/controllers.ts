namespace JobBoardApp.Controllers {

    export class HomeController {
        public message = 'Hello from the home page!';
        public jobs;
        public jobsUrl = "http://api.glassdoor.com/api/api.htm?t.p=145417&t.k=jpMvfETM5pS&userip=0.0.0.0&useragent=&format=json&v=1&action=jobs-stats&returnStates=true&admLevelRequested=1";



        constructor(private $http: ng.IHttpService) {

            this.$http.get(this.jobsUrl)
                .then((response) => {
                    this.jobs = response.data;
                });
        }
    }
    export class JobController {
        public JobResource;
        public jobList;
        public jobs;
        public jobTitle;
        public jobToSave;
        public jobTitleUrl = "http://api.glassdoor.com/api/api.htm?v=1&format=json&t.p=145417&t.k=jpMvfETM5pS&action=employers&q=pharmaceuticals&userip=192.168.43.42&useragent=Mozilla/%2F4.0";
        public getJobs() {
            this.jobList = this.JobResource.query();
        }

        public save() {
            this.JobResource.save(this.jobs).$promise.then(() => {
                this.jobs = null;
                this.JobResource();
            });
        }

        public saveJob() {
            console.log(this.jobs);
            this.JobService.addJob(this.jobs.id).then(
                () => this.$state.go('secret')
            );
            
        }

        public saveAJob(id) {
            this.$http.post('/api/jobs', id).then((response) => {
                this.$state.go('secret')
            });
            console.log(id);

        }



        constructor(private $http: ng.IHttpService, private $resource: ng.resource.IResourceService, private JobService: JobBoardApp.Services.JobService, private $state: ng.ui.IStateService, $stateParams: ng.ui.IStateParamsService) {
            $http.get(this.jobTitleUrl).then((results) => {
                this.jobTitle = results.data;
                console.log(this.jobTitle);
            });
            this.JobResource = $resource('/api/job/:id');
            this.getJobs();
        }
    }
    export class PostJobController {
        public jobToCreate;

        addJob() {
            this.JobService.save(this.jobToCreate).then(
                () => this.$state.go('jobListings')
            );

        }

        constructor(private JobService: JobBoardApp.Services.JobService, private $state: ng.ui.IStateService) { }
    }
    angular.module('JobBoardApp').controller('PostJobController', PostJobController);

    export class ResumeController {

    }
    export class SecretController {
        public secrets;
        public jobs;

        public saveJob() {
            console.log(this.jobs);
            this.JobService.addJob(this.jobs.id).then(
                () => this.$state.go('secret')
            );

        }

        public saveAJob(id) {
            this.$http.post('/api/jobs', id).then((response) => {
                this.$state.reload();
                this.$state.go('secret')
            });
            console.log(id);

        }

        constructor(private $http: ng.IHttpService, private $resource: ng.resource.IResourceService, private JobService: JobBoardApp.Services.JobService, private $state: ng.ui.IStateService, $stateParams: ng.ui.IStateParamsService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }

    export class JobDeleteController {
        public jobToDelete;

        public deleteJob() {
            this.JobService.deleteJob(this.jobToDelete.id).then(
                () => this.$state.go('secret')
            );
        }

        constructor(private JobService: JobBoardApp.Services.JobService, private $state: ng.ui.IStateService, $stateParams: ng.ui.IStateParamsService) {
            this.jobToDelete = JobService.getJob($stateParams['id'])
        }
    }

    angular.module('JobBoardApp').controller('JobDeleteController', JobDeleteController);

    export class AboutController {
        public message = 'Hello from the about page!';
    }

    export class JobToSaveController {
        public jobToSave;

        public saveJob() {
            this.JobService.addJob(this.jobToSave.id).then(
                () => this.$state.go('secret')
            );
        }

        constructor(private JobService: JobBoardApp.Services.JobService, private $state: ng.ui.IStateService, $stateParams: ng.ui.IStateParamsService) {
            this.jobToSave = JobService.getJob($stateParams['id'])
        }
    }

    angular.module('JobBoardApp').controller('JobDeleteController', JobDeleteController);
}
