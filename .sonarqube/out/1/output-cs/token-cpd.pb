½$
UC:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Infrastructure\ApplicationDbContext.cs
	namespace 	
YourOSBB
 
. 
Infrastructure !
;! "
public

 
class

  
ApplicationDbContext

 !
:

" #
IdentityDbContext

$ 5
<

5 6
ApplicationUser

6 E
,

E F
ApplicationRole

G V
,

V W
int

X [
>

[ \
{ 
public 

DbSet 
< 
ApplicationUser  
>  !
ApplicationUsers" 2
{3 4
get5 8
;8 9
set: =
;= >
}? @
public 

DbSet 
< 
Osbb 
> 
Osbb 
{ 
get !
;! "
set# &
;& '
}( )
public 

DbSet 
< 
Announcement 
> 
Announcement +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 

DbSet 
< 
	Complaint 
> 
	Complaint %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 

DbSet 
< 
Proposal 
> 
Proposal #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 

DbSet 
< 
Tariff 
> 
Tariff 
{  !
get" %
;% &
set' *
;* +
}, -
public 

DbSet 
< 
Poll 
> 
Poll 
{ 
get !
;! "
set# &
;& '
}( )
public 

DbSet 
< 
PollCandidate 
> 
PollCandidate  -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
public 

DbSet 
< 
UserVote 
> 
UserVote #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 

DbSet 
< 
CompletedPoll 
> 
CompletedPoll  -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
public 
 
ApplicationDbContext 
(  
)  !
{ 
} 
public 
 
ApplicationDbContext 
(  
DbContextOptions  0
<0 1 
ApplicationDbContext1 E
>E F
optionsG N
)N O
: 	
base
 
( 
options 
) 
{ 
Database 
. 
EnsureCreated 
( 
)  
;  !
} 
	protected!! 
override!! 
void!! 
OnModelCreating!! +
(!!+ ,
ModelBuilder!!, 8
builder!!9 @
)!!@ A
{"" 
base## 
.## 
OnModelCreating## 
(## 
builder## $
)##$ %
;##% &
builder'' 
.'' 
Entity'' 
<'' 
ApplicationUser'' &
>''& '
(''' (
entity''( .
=>''/ 1
{''2 3
entity''4 :
.'': ;
ToTable''; B
(''B C
$str''C U
)''U V
;''V W
}''X Y
)''Y Z
;''Z [
builder)) 
.)) 
Entity)) 
<)) 
Osbb)) 
>)) 
()) 
))) 
.** 
HasMany** 
(** 
e** 
=>** 
e** 
.** 
	Residents** %
)**% &
.++ 
WithOne++ 
(++ 
e++ 
=>++ 
e++ 
.++ 
Osbb++  
)++  !
.,, 
HasForeignKey,, 
(,, 
e,, 
=>,, 
e,,  !
.,,! "
OsbbId,," (
),,( )
.-- 

IsRequired-- 
(-- 
false-- 
)-- 
;-- 
}.. 
	protected00 
override00 
void00 
OnConfiguring00 )
(00) *#
DbContextOptionsBuilder00* A
optionsBuilder00B P
)00P Q
{11 
}33 
}44 ¹
cC:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Infrastructure\Interfaces\IAnnouncementRepository.cs
	namespace 	
YourOSBB
 
. 
Infrastructure !
.! "

Interfaces" ,
;, -
public 
	interface #
IAnnouncementRepository (
:) *
IRepository+ 6
<6 7
Announcement7 C
>C D
{ 
} Â
`C:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Infrastructure\Interfaces\IComplaintRepository.cs
	namespace 	
YourOSBB
 
. 
Infrastructure !
.! "

Interfaces" ,
;, -
public 
	interface  
IComplaintRepository %
:& '
IRepository( 3
<3 4
	Complaint4 =
>= >
{ 
public 

Task 
Update 
( 
	Complaint  
entity! '
)' (
;( )
} ç
fC:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Infrastructure\Interfaces\IApplicationUserRepository.cs
	namespace 	
YourOSBB
 
. 
Infrastructure !
.! "

Interfaces" ,
;, -
public 
	interface &
IApplicationUserRepository +
:, -
IRepository. 9
<9 :
ApplicationUser: I
>I J
{ 
public 

Task 
Update 
( 
ApplicationUser &
entity' -
)- .
;. /
public

 

Task

 
<

 
IEnumerable

 
<

 
ApplicationUser

 +
>

+ ,
>

, -!
GetAllResidentsInOsbb

. C
(

C D
int

D G
osbbId

H N
)

N O
;

O P
} ¼
dC:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Infrastructure\Interfaces\ICompletedPollRepository.cs
	namespace 	
YourOSBB
 
. 
Infrastructure !
.! "

Interfaces" ,
;, -
public 
	interface $
ICompletedPollRepository )
:* +
IRepository, 7
<7 8
CompletedPoll8 E
>E F
{ 
} ®
[C:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Infrastructure\Interfaces\IOsbbRepository.cs
	namespace 	
YourOSBB
 
. 
Infrastructure !
.! "

Interfaces" ,
;, -
public 
	interface 
IOsbbRepository  
:! "
IRepository# .
<. /
Osbb/ 3
>3 4
{ 
public 

Task 
Update 
( 
Osbb 
entity "
)" #
;# $
} ¼
dC:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Infrastructure\Interfaces\IPollCandidateRepository.cs
	namespace 	
YourOSBB
 
. 
Infrastructure !
.! "

Interfaces" ,
;, -
public 
	interface $
IPollCandidateRepository )
:* +
IRepository, 7
<7 8
PollCandidate8 E
>E F
{ 
} ¡
[C:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Infrastructure\Interfaces\IPollRepository.cs
	namespace 	
YourOSBB
 
. 
Infrastructure !
.! "

Interfaces" ,
;, -
public 
	interface 
IPollRepository  
:! "
IRepository# .
<. /
Poll/ 3
>3 4
{ 
} ¾
_C:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Infrastructure\Interfaces\IProposalRepository.cs
	namespace 	
YourOSBB
 
. 
Infrastructure !
.! "

Interfaces" ,
;, -
public 
	interface 
IProposalRepository $
:% &
IRepository' 2
<2 3
Proposal3 ;
>; <
{ 
public 

Task 
Update 
( 
Proposal 
entity  &
)& '
;' (
} 
WC:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Infrastructure\Interfaces\IRepository.cs
	namespace 	
YourOSBB
 
. 
Infrastructure !
.! "

Interfaces" ,
;, -
public 
	interface 
IRepository 
< 
T 
> 
where  %
T& '
:( )
class* /
{ 
Task 
< 	
T	 

>
 
AddAsync 
( 
T 
entity 
) 
; 
Task 
DeleteAsync	 
( 
T 
entity 
) 
; 
Task		 
DeleteManyAsync			 
(		 

Expression		 #
<		# $
Func		$ (
<		( )
T		) *
,		* +
bool		, 0
>		0 1
>		1 2
filter		3 9
)		9 :
;		: ;
Task

 
<

 	
IEnumerable

	 
<

 
T

 
>

 
>

 
GetAllAsync

 $
(

$ %
)

% &
;

& '
Task 
< 	
T	 

>
 
GetByIdAsync 
( 
int 
id 
)  
;  !
Task 
< 	
IEnumerable	 
< 
T 
> 
> 
GetManyAsync %
(% &

Expression 
< 
Func 
< 
T 
, 
bool 
>  
>  !
filter" (
=) *
null+ /
,/ 0
Func 
< 

IQueryable 
< 
T 
> 
, 
IOrderedQueryable -
<- .
T. /
>/ 0
>0 1
orderBy2 9
=: ;
null< @
,@ A
int 
? 
top 
= 
null 
, 
int 
? 
skip 
= 
null 
, 
params 
string 
[ 
] 
includeProperties )
)) *
;* +
} ¶
]C:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Infrastructure\Interfaces\ITariffRepository.cs
	namespace 	
YourOSBB
 
. 
Infrastructure !
.! "

Interfaces" ,
;, -
public 
	interface 
ITariffRepository "
:# $
IRepository% 0
<0 1
Tariff1 7
>7 8
{ 
public 

Task 
Update 
( 
Tariff 
entity $
)$ %
;% &
} †
WC:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Infrastructure\Interfaces\IUnitOfWork.cs
	namespace 	
YourOSBB
 
. 
Infrastructure !
.! "

Interfaces" ,
;, -
public 
	interface 
IUnitOfWork 
: 
IAsyncDisposable /
{ 
IOsbbRepository 
OsbbRepository "
{# $
get% (
;( )
}* +&
IApplicationUserRepository		 %
ApplicationUserRepository		 8
{		9 :
get		; >
;		> ?
}		@ A#
IAnnouncementRepository

 "
AnnouncementRepository

 2
{

3 4
get

5 8
;

8 9
}

: ;
IProposalRepository 
ProposalRepository *
{+ ,
get- 0
;0 1
}2 3 
IComplaintRepository 
ComplaintRepository ,
{- .
get/ 2
;2 3
}4 5
ITariffRepository 
TariffRepository &
{' (
get) ,
;, -
}. /
IPollRepository 
PollRepository "
{# $
get% (
;( )
}* +$
IPollCandidateRepository #
PollCandidateRepository 4
{5 6
get7 :
;: ;
}< =
IUserVoteRepository 
UserVoteRepository *
{+ ,
get- 0
;0 1
}2 3$
ICompletedPollRepository #
CompletedPollRepository 4
{5 6
get7 :
;: ;
}< =
UserManager 
< 
ApplicationUser 
>  "
ApplicationUserManager! 7
{8 9
get: =
;= >
}? @
Task 
DoAsync	 
( 
) 
; 
} ­
_C:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Infrastructure\Interfaces\IUserVoteRepository.cs
	namespace 	
YourOSBB
 
. 
Infrastructure !
.! "

Interfaces" ,
;, -
public 
	interface 
IUserVoteRepository $
:% &
IRepository' 2
<2 3
UserVote3 ;
>; <
{ 
} â
dC:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Infrastructure\Repositories\AnnouncementRepository.cs
	namespace 	
YourOSBB
 
. 
Infrastructure !
.! "
Repositories" .
;. /
public 
class "
AnnouncementRepository #
:$ %

Repository& 0
<0 1
Announcement1 =
>= >
,> ?#
IAnnouncementRepository@ W
{ 
public		 
"
AnnouncementRepository		 !
(		! "
	DbContext		" +
	dbContext		, 5
)		5 6
:		7 8
base		9 =
(		= >
	dbContext		> G
)		G H
{

 
} 
} û
gC:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Infrastructure\Repositories\ApplicationUserRepository.cs
	namespace 	
YourOSBB
 
. 
Infrastructure !
.! "
Repositories" .
;. /
public 
class %
ApplicationUserRepository &
:' (

Repository) 3
<3 4
ApplicationUser4 C
>C D
,D E&
IApplicationUserRepositoryF `
{ 
public		 
%
ApplicationUserRepository		 $
(		$ %
	DbContext		% .
	dbContext		/ 8
)		8 9
:		: ;
base		< @
(		@ A
	dbContext		A J
)		J K
{

 
} 
public 

async 
Task 
Update 
( 
ApplicationUser ,
entity- 3
)3 4
{ 
ApplicationUser 
find 
= 
await $
GetByIdAsync% 1
(1 2
entity2 8
.8 9
Id9 ;
); <
;< =

_dbContext 
. 
Entry 
( 
find 
) 
. 
CurrentValues ,
., -
	SetValues- 6
(6 7
entity7 =
)= >
;> ?
} 
public 

async 
Task 
< 
IEnumerable !
<! "
ApplicationUser" 1
>1 2
>2 3!
GetAllResidentsInOsbb4 I
(I J
intJ M
osbbIdN T
)T U
{ 
IEnumerable 
< 
ApplicationUser #
># $
find% )
=* +
await, 1
_dbSet2 8
.8 9
ToListAsync9 D
(D E
)E F
;F G
return 
find 
. 
Where 
( 
x 
=> 
x  
.  !
OsbbId! '
==( *
osbbId+ 1
)1 2
;2 3
} 
} Ð

aC:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Infrastructure\Repositories\ComplaintRepository.cs
	namespace 	
YourOSBB
 
. 
Infrastructure !
.! "
Repositories" .
;. /
public 
class 
ComplaintRepository  
:! "

Repository# -
<- .
	Complaint. 7
>7 8
,8 9 
IComplaintRepository: N
{ 
public		 

ComplaintRepository		 
(		 
	DbContext		 (
	dbContext		) 2
)		2 3
:		4 5
base		6 :
(		: ;
	dbContext		; D
)		D E
{

 
} 
public 

async 
Task 
Update 
( 
	Complaint &
entity' -
)- .
{ 
	Complaint 
find 
= 
await 
GetByIdAsync +
(+ ,
entity, 2
.2 3
ComplaintId3 >
)> ?
;? @

_dbContext 
. 
Entry 
( 
find 
) 
. 
CurrentValues ,
., -
	SetValues- 6
(6 7
entity7 =
)= >
;> ?
} 
} ç
eC:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Infrastructure\Repositories\CompletedPollRepository.cs
	namespace 	
YourOSBB
 
. 
Infrastructure !
.! "
Repositories" .
;. /
public 
class #
CompletedPollRepository $
:% &

Repository' 1
<1 2
CompletedPoll2 ?
>? @
,@ A$
ICompletedPollRepositoryB Z
{ 
public		 
#
CompletedPollRepository		 "
(		" #
	DbContext		# ,
	dbContext		- 6
)		6 7
:		8 9
base		: >
(		> ?
	dbContext		? H
)		H I
{

 
} 
} ¨

\C:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Infrastructure\Repositories\OsbbRepository.cs
	namespace 	
YourOSBB
 
. 
Infrastructure !
.! "
Repositories" .
;. /
public 
class 
OsbbRepository 
: 

Repository (
<( )
Osbb) -
>- .
,. /
IOsbbRepository0 ?
{ 
public		 

OsbbRepository		 
(		 
	DbContext		 #
	dbContext		$ -
)		- .
:		/ 0
base		1 5
(		5 6
	dbContext		6 ?
)		? @
{

 
} 
public 

async 
Task 
Update 
( 
Osbb !
entity" (
)( )
{ 
Osbb 
find 
= 
await 
GetByIdAsync &
(& '
entity' -
.- .
OsbbId. 4
)4 5
;5 6

_dbContext 
. 
Entry 
( 
find 
) 
. 
CurrentValues ,
., -
	SetValues- 6
(6 7
entity7 =
)= >
;> ?
} 
} ç
eC:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Infrastructure\Repositories\PollCandidateRepository.cs
	namespace 	
YourOSBB
 
. 
Infrastructure !
.! "
Repositories" .
;. /
public 
class #
PollCandidateRepository $
:% &

Repository' 1
<1 2
PollCandidate2 ?
>? @
,@ A$
IPollCandidateRepositoryB Z
{ 
public		 
#
PollCandidateRepository		 "
(		" #
	DbContext		# ,
	dbContext		- 6
)		6 7
:		8 9
base		: >
(		> ?
	dbContext		? H
)		H I
{

 
} 
} º
\C:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Infrastructure\Repositories\PollRepository.cs
	namespace 	
YourOSBB
 
. 
Infrastructure !
.! "
Repositories" .
;. /
public 
class 
PollRepository 
: 

Repository (
<( )
Poll) -
>- .
,. /
IPollRepository0 ?
{ 
public		 

PollRepository		 
(		 
	DbContext		 #
	dbContext		$ -
)		- .
:		/ 0
base		1 5
(		5 6
	dbContext		6 ?
)		? @
{

 
} 
} È

`C:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Infrastructure\Repositories\ProposalRepository.cs
	namespace 	
YourOSBB
 
. 
Infrastructure !
.! "
Repositories" .
;. /
public 
class 
ProposalRepository 
:  !

Repository" ,
<, -
Proposal- 5
>5 6
,6 7
IProposalRepository8 K
{ 
public		 

ProposalRepository		 
(		 
	DbContext		 '
	dbContext		( 1
)		1 2
:		3 4
base		5 9
(		9 :
	dbContext		: C
)		C D
{

 
} 
public 

async 
Task 
Update 
( 
Proposal %
entity& ,
), -
{ 
Proposal 
find 
= 
await 
GetByIdAsync *
(* +
entity+ 1
.1 2

ProposalId2 <
)< =
;= >

_dbContext 
. 
Entry 
( 
find 
) 
. 
CurrentValues ,
., -
	SetValues- 6
(6 7
entity7 =
)= >
;> ?
} 
} Æ2
XC:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Infrastructure\Repositories\Repository.cs
	namespace 	
YourOSBB
 
. 
Infrastructure !
.! "
Repositories" .
;. /
public 
class 

Repository 
< 
T 
> 
: 
IRepository (
<( )
T) *
>* +
where, 1
T2 3
:4 5
class6 ;
{		 
	protected

 
readonly

 
	DbContext

  

_dbContext

! +
;

+ ,
	protected 
readonly 
DbSet 
< 
T 
> 
_dbSet! '
;' (
public 


Repository 
( 
	DbContext 
	dbContext  )
)) *
{ 

_dbContext 
= 
	dbContext 
; 
_dbSet 
= 

_dbContext 
. 
Set 
<  
T  !
>! "
(" #
)# $
;$ %
} 
public 

async 
Task 
< 
T 
> 
AddAsync !
(! "
T" #
entity$ *
)* +
{ 
await 
_dbSet 
. 
AddAsync 
( 
entity $
)$ %
;% &
return 
entity 
; 
} 
public 

Task 
DeleteAsync 
( 
T 
entity $
)$ %
{ 
_dbSet 
. 
Remove 
( 
entity 
) 
; 
return 
Task 
. 
CompletedTask !
;! "
} 
public 

Task 
DeleteManyAsync 
(  

Expression  *
<* +
Func+ /
</ 0
T0 1
,1 2
bool3 7
>7 8
>8 9
filter: @
)@ A
{   
var!! 
entities!! 
=!! 
_dbSet!! 
.!! 
Where!! #
(!!# $
filter!!$ *
)!!* +
;!!+ ,
_dbSet"" 
."" 
RemoveRange"" 
("" 
entities"" #
)""# $
;""$ %
return## 
Task## 
.## 
CompletedTask## !
;##! "
}$$ 
public&& 

async&& 
Task&& 
<&& 
IEnumerable&& !
<&&! "
T&&" #
>&&# $
>&&$ %
GetAllAsync&&& 1
(&&1 2
)&&2 3
{'' 
return(( 
await(( 
_dbSet(( 
.(( 
ToListAsync(( '
(((' (
)((( )
;(() *
})) 
public++ 

async++ 
Task++ 
<++ 
T++ 
>++ 
GetByIdAsync++ %
(++% &
int++& )
id++* ,
)++, -
{,, 
return-- 
await-- 
_dbSet-- 
.-- 
	FindAsync-- %
(--% &
id--& (
)--( )
;--) *
}.. 
public00 

async00 
Task00 
<00 
IEnumerable00 !
<00! "
T00" #
>00# $
>00$ %
GetManyAsync00& 2
(002 3

Expression11 
<11 
Func11 
<11 
T11 
,11 
bool11 
>11  
>11  !
filter11" (
=11) *
null11+ /
,11/ 0
Func22 
<22 

IQueryable22 
<22 
T22 
>22 
,22 
IOrderedQueryable22 -
<22- .
T22. /
>22/ 0
>220 1
orderBy222 9
=22: ;
null22< @
,22@ A
int33 
?33 
top33 
=33 
null33 
,33 
int44 
?44 
skip44 
=44 
null44 
,44 
params55 
string55 
[55 
]55 
includeProperties55 )
)55) *
{66 

IQueryable77 
<77 
T77 
>77 
query77 
=77 
_dbSet77 $
;77$ %
if99 

(99 
filter99 
!=99 
null99 
)99 
{:: 	
query;; 
=;; 
query;; 
.;; 
Where;; 
(;;  
filter;;  &
);;& '
;;;' (
}<< 	
if== 

(== 
includeProperties== 
.== 
Length== $
>==% &
$num==' (
)==( )
{>> 	
query?? 
=?? 
includeProperties?? %
.??% &
	Aggregate??& /
(??/ 0
query??0 5
,??5 6
(??7 8
theQuery??8 @
,??@ A

theInclude??B L
)??L M
=>??N P
theQuery??Q Y
.??Y Z
Include??Z a
(??a b

theInclude??b l
)??l m
)??m n
;??n o
}@@ 	
ifAA 

(AA 
orderByAA 
!=AA 
nullAA 
)AA 
{BB 	
queryCC 
=CC 
orderByCC 
(CC 
queryCC !
)CC! "
;CC" #
}DD 	
ifEE 

(EE 
skipEE 
.EE 
HasValueEE 
)EE 
{FF 	
queryGG 
=GG 
queryGG 
.GG 
SkipGG 
(GG 
skipGG #
.GG# $
ValueGG$ )
)GG) *
;GG* +
}HH 	
ifII 

(II 
topII 
.II 
HasValueII 
)II 
{JJ 	
queryKK 
=KK 
queryKK 
.KK 
TakeKK 
(KK 
topKK "
.KK" #
ValueKK# (
)KK( )
;KK) *
}LL 	
returnMM 
awaitMM 
queryMM 
.MM 
ToListAsyncMM &
(MM& '
)MM' (
;MM( )
}NN 
}OO ¸

^C:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Infrastructure\Repositories\TariffRepository.cs
	namespace 	
YourOSBB
 
. 
Infrastructure !
.! "
Repositories" .
;. /
public 
class 
TariffRepository 
: 

Repository  *
<* +
Tariff+ 1
>1 2
,2 3
ITariffRepository4 E
{ 
public		 

TariffRepository		 
(		 
	DbContext		 %
	dbContext		& /
)		/ 0
:		1 2
base		3 7
(		7 8
	dbContext		8 A
)		A B
{

 
} 
public 

async 
Task 
Update 
( 
Tariff #
entity$ *
)* +
{ 
Tariff 
find 
= 
await 
GetByIdAsync (
(( )
entity) /
./ 0
TariffId0 8
)8 9
;9 :

_dbContext 
. 
Entry 
( 
find 
) 
. 
CurrentValues ,
., -
	SetValues- 6
(6 7
entity7 =
)= >
;> ?
} 
} Î
`C:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Infrastructure\Repositories\UserVoteRepository.cs
	namespace 	
YourOSBB
 
. 
Infrastructure !
.! "
Repositories" .
;. /
public 
class 
UserVoteRepository 
:  !

Repository" ,
<, -
UserVote- 5
>5 6
,6 7
IUserVoteRepository8 K
{ 
public		 

UserVoteRepository		 
(		 
	DbContext		 '
	dbContext		( 1
)		1 2
:		3 4
base		5 9
(		9 :
	dbContext		: C
)		C D
{

 
} 
} ³2
KC:\Users\vanya\RiderProjects\YourOSBB\YourOSBB.Infrastructure\UnitOfWork.cs
	namespace 	
YourOSBB
 
. 
Infrastructure !
;! "
public 
class 

UnitOfWork 
: 
IUnitOfWork %
{		 
public

 

IOsbbRepository

 
OsbbRepository

 )
{

* +
get

, /
;

/ 0
private

1 8
set

9 <
;

< =
}

> ?
public 
&
IApplicationUserRepository %%
ApplicationUserRepository& ?
{@ A
getB E
;E F
privateG N
setO R
;R S
}T U
public 
#
IAnnouncementRepository ""
AnnouncementRepository# 9
{: ;
get< ?
;? @
privateA H
setI L
;L M
}N O
public 

IProposalRepository 
ProposalRepository 1
{2 3
get4 7
;7 8
private9 @
setA D
;D E
}F G
public 
 
IComplaintRepository 
ComplaintRepository  3
{4 5
get6 9
;9 :
private; B
setC F
;F G
}H I
public 

ITariffRepository 
TariffRepository -
{. /
get0 3
;3 4
private5 <
set= @
;@ A
}B C
public 

IPollRepository 
PollRepository )
{* +
get, /
;/ 0
private1 8
set9 <
;< =
}> ?
public 
$
IPollCandidateRepository ##
PollCandidateRepository$ ;
{< =
get> A
;A B
privateC J
setK N
;N O
}P Q
public 

IUserVoteRepository 
UserVoteRepository 1
{2 3
get4 7
;7 8
private9 @
setA D
;D E
}F G
public 
$
ICompletedPollRepository ##
CompletedPollRepository$ ;
{< =
get> A
;A B
privateC J
setK N
;N O
}P Q
public 

UserManager 
< 
ApplicationUser &
>& '"
ApplicationUserManager( >
{? @
getA D
;D E
privateF M
setN Q
;Q R
}S T
private 
readonly  
ApplicationDbContext )

_dbContext* 4
;4 5
public 


UnitOfWork 
(  
ApplicationDbContext 
	dbContext &
,& '
UserManager 
< 
ApplicationUser #
># $
userManager% 0
)0 1
{ 

_dbContext 
= 
	dbContext 
?? !
throw" '
new( +!
ArgumentNullException, A
(A B
nameofB H
(H I
	dbContextI R
)R S
)S T
;T U"
ApplicationUserManager 
=  
userManager! ,
;, -
OsbbRepository 
= 
new 
OsbbRepository +
(+ ,
	dbContext, 5
)5 6
;6 7%
ApplicationUserRepository !
=" #
new$ '%
ApplicationUserRepository( A
(A B
	dbContextB K
)K L
;L M"
AnnouncementRepository   
=    
new  ! $"
AnnouncementRepository  % ;
(  ; <
	dbContext  < E
)  E F
;  F G
ProposalRepository!! 
=!! 
new!!  
ProposalRepository!!! 3
(!!3 4
	dbContext!!4 =
)!!= >
;!!> ?
ComplaintRepository"" 
="" 
new"" !
ComplaintRepository""" 5
(""5 6
	dbContext""6 ?
)""? @
;""@ A
TariffRepository## 
=## 
new## 
TariffRepository## /
(##/ 0
	dbContext##0 9
)##9 :
;##: ;
PollRepository$$ 
=$$ 
new$$ 
PollRepository$$ +
($$+ ,
	dbContext$$, 5
)$$5 6
;$$6 7#
PollCandidateRepository%% 
=%%  !
new%%" %#
PollCandidateRepository%%& =
(%%= >
	dbContext%%> G
)%%G H
;%%H I
UserVoteRepository&& 
=&& 
new&&  
UserVoteRepository&&! 3
(&&3 4
	dbContext&&4 =
)&&= >
;&&> ?#
CompletedPollRepository'' 
=''  !
new''" %#
CompletedPollRepository''& =
(''= >
	dbContext''> G
)''G H
;''H I
}(( 
public** 

async** 
Task** 
DoAsync** 
(** 
)** 
=>**  "
await**# (

_dbContext**) 3
.**3 4
SaveChangesAsync**4 D
(**D E
)**E F
;**F G
private,, 
bool,, 
	_disposed,, 
;,, 
public.. 


UnitOfWork.. 
(.. 
).. 
{// 
}11 
public33 

async33 
	ValueTask33 
DisposeAsync33 '
(33' (
)33( )
{44 
await55 
DisposeAsync55 
(55 
true55 
)55  
;55  !
GC66 

.66
 
SuppressFinalize66 
(66 
this66  
)66  !
;66! "
}77 
	protected99 
virtual99 
async99 
	ValueTask99 %
DisposeAsync99& 2
(992 3
bool993 7
	disposing998 A
)99A B
{:: 
if;; 

(;; 
!;; 
	_disposed;; 
);; 
{<< 	
if== 
(== 
	disposing== 
)== 
{>> 
await?? 

_dbContext??  
.??  !
DisposeAsync??! -
(??- .
)??. /
;??/ 0
}@@ 
	_disposedAA 
=AA 
trueAA 
;AA 
}BB 	
}CC 
}DD 