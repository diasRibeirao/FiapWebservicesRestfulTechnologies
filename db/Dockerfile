FROM mysql:5.7.22
EXPOSE 3306
COPY ./FiapWebservicesRestfulTechnologies/db/migrations/ /home/database/
COPY ./FiapWebservicesRestfulTechnologies/db/dataset/ /home/database/
COPY ./FiapWebservicesRestfulTechnologies/ci/init_database.sh/ /docker-entrypoint-initdb.d/init_database.sh