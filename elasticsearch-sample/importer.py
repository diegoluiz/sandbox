import csv
import requests
from datetime import datetime
from elasticsearch import Elasticsearch
from elasticsearch import helpers
from munch import munchify

data = []

print("Loading file")
with open('movie_metadata.csv') as csvfile:
    reader = csv.DictReader(csvfile)
    for row in reader:
        obj = munchify(row)
        obj.__setattr__('_index', 'movies')
        obj.__setattr__('_type', 'movie')

        genres = obj.genres.split('|')
        obj.__setattr__('genres', genres)

        plot_keywords =  obj.plot_keywords.split('|')
        obj.__setattr__('plot_keywords', plot_keywords)

        data.append(obj)

print("Loaded ", len(data), "lines")

# for i in range(2):
#     print(data[i])
#     print("")

print("Creating indexes")
es = Elasticsearch()
es.indices.delete(index='movies', ignore=404)
mapping = {
    "properties" : {
        "num_critic_for_reviews": { "type": "integer" },
        "duration": { "type": "integer" },
        "director_facebook_likes": { "type": "integer" },
        "actor_1_facebook_likes": { "type": "integer" },
        "actor_2_facebook_likes": { "type": "integer" },
        "actor_3_facebook_likes": { "type": "integer" },
        "gross": { "type": "integer" },
        "num_voted_users": { "type": "integer" },
        "cast_total_facebook_likes": { "type": "integer" },
        "num_user_for_reviews": { "type": "integer" },
        "budget": { "type": "float" },
        "title_year": { "type": "integer" },
        "imdb_score": { "type": "float" },
        "aspect_ratio": { "type": "float" },
        "movie_facebook_likes": { "type": "integer" }
    }
}
settings = {
    "index": {
        "number_of_shards" : 3, 
        "number_of_replicas" : 2 
    }
}
es.indices.create(index='movies', body={"settings": settings, "mappings": mapping }, ignore=400)
print("Index created")

print("Loading documents")
helpers.bulk(es, data)
print("Load completed")


print("Script Finished")
