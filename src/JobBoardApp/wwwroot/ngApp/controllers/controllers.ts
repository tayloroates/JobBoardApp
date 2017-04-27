namespace JobBoardApp.Controllers {

    export class HomeController {
        public message = 'Hello from the home page!';

    }
    export class JobController {
        public jobs;

        constructor($http: ng.IHttpService) {
            $http.get('http://api.glassdoor.com/api/api.htm?v=1&format=json&t.p=145417&t.k=jpMvfETM5pS&action=employers&q=pharmaceuticals&userip=192.168.43.42&useragent=Mozilla/%2F4.0').then((results) => {
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
