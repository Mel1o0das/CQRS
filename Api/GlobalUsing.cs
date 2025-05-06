global using Api;
global using Infrastructure;
global using Infrastructure.Data.Extensions;
global using Application.Dtos.TopicDto;
//global using Application.Topics;
global using Application.Exceptions;

global using Application.Topics.Queries.GetTopics;
global using MediatR;

global using Application.Topics.Queries.GetTopic;
global using Application.Topics.Commands.CreateTopicCommand;
global using Application.Topics.Commands.DeleteTopicCommand;

global using Application.Mapping;

global using Microsoft.AspNetCore.Mvc;
global using Domain.Interfaces;
global using Domain.Models;
global using System.Text;
global using Microsoft.IdentityModel.Tokens;