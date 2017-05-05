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
        public jobTitle;
        public jobTitleUrl = "http://api.glassdoor.com/api/api.htm?v=1&format=json&t.p=145417&t.k=jpMvfETM5pS&action=employers&q=pharmaceuticals&userip=192.168.43.42&useragent=Mozilla/%2F4.0";

        constructor(private $http: ng.IHttpService) {
            $http.get(this.jobTitleUrl).then((results) => {
                this.jobTitle = results.data;
            });
        }
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
