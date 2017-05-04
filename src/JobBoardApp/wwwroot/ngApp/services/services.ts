namespace JobBoardApp.Services {
    export class JobService {
        public jobResource;

        public getJobs() {
            return this.jobResource.query();
        }

        public save(job) {
            return this.jobResource.save(job).$promise;
        }
        public deleteJob(id: number) {
            return this.jobResource.delete({ id: id }).$promise;
        }
        public getJob(id) {
            return this.jobResource.get({ id: id });
        }
        constructor($resource: ng.resource.IResourceService) {
            this.jobResource = $resource('http://api.glassdoor.com/api/api.htm?t.p=145417&t.k=jpMvfETM5pS&userip=0.0.0.0&useragent=&format=json&v=1&action=jobs-stats&returnStates=true&admLevelRequested=1');
        }

    }
    angular.module('JobBoardApp').service('JobService', JobService);

}

