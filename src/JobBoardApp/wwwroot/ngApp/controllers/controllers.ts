namespace JobBoardApp.Controllers {

    export class HomeController {
        public message = 'Hello from the home page!';
    
        public jobs = "http://api.glassdoor.com/api/api.htm?t.p=145417&t.k=jpMvfETM5pS&userip=0.0.0.0&useragent=&format=json&v=1&action=jobs-stats&returnStates=true&admLevelRequested=1";

        
        constructor(private $http: ng.IHttpService) {
            this.$http.get('/api/jobs')
                .then((response) => {
                    this.jobs = response.data;
                });
        }
    }
    export class JobController {
        public jobs;

        constructor($http: ng.IHttpService) {
            $http.get('http://api.glassdoor.com/api/api.htm?t.p=145417&t.k=jpMvfETM5pS&userip=0.0.0.0&useragent=&format=json&v=1&action=jobs-stats&returnStates=true&admLevelRequested=1').then((results) => {
                this.jobs = results.data;
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
