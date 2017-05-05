namespace JobBoardApp.Controllers {

    export class HomeController {
        public message = 'Hello from the home page!';
        public JobResource;
        public jobs;
        public jobsUrl = "http://api.glassdoor.com/api/api.htm?t.p=145417&t.k=jpMvfETM5pS&userip=0.0.0.0&useragent=&format=json&v=1&action=jobs-stats&returnStates=true&admLevelRequested=1";

        public getJobs() {
            this.jobs = this.JobResource.query();

        }

        public save() {
            this.JobResource.save(this.jobs).$promise.then(() => {
                this.jobs = null;
                this.getJobs();
            });
        }


        constructor(private $http: ng.IHttpService,) {
            //this.JobResource = $resource(this.jobUrl);
            //this.getJobs();

            this.$http.get(this.jobsUrl)
                .then((response) => {
                    this.jobs = response.data;
                });
        }
    }
    export class JobController {
        public jobTitleResource;
        public jobTitle;
        public jobTitleUrl = "http://api.glassdoor.com/api/api.htm?v=1&format=json&t.p=145417&t.k=jpMvfETM5pS&action=employers&q=pharmaceuticals&userip=192.168.43.42&useragent=Mozilla/%2F4.0";

        public getJobTitle() {
            this.jobTitle = this.jobTitleResource.query();

        }

        public save() {
            this.jobTitleResource.save(this.jobTitle).$promise.then(() => {
                this.jobTitle = null;
                this.getJobTitle();
            });
        }
        constructor(private $resource: ng.resource.IResourceService, private $http: ng.IHttpService) {
            $http.get(this.jobTitleUrl).then((results) => {
                this.jobTitle = results.data;
            });
        }
    }
    export class ResumeController {
        public message = 'Hello from the about page!';
    }

    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }


    export class AboutController {
        public message = 'Hello from the about page!';
    }

}
