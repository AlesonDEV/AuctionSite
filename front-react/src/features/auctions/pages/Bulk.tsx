import React from 'react';
import Box from "@mui/joy/Box";
import {Divider, List, ListItem, Sheet} from "@mui/joy";
// import Typography from "@mui/joy/Typography";
// import ButtonLink from "@/features/home/sections/components/ButtonLink";
import AuctionListItem from "@/features/auctions/components/AuctionListItem";
import AuctionsApiManager from "@/features/auctions/api/AuctionsApiManager";
import Typography from "@mui/joy/Typography";


const Bulk = async () => {
    const AuctionData = await AuctionsApiManager.getAuctions({count: 10})

    return (
        <section>
            <Box sx={{
                flex: '1',
                width: '100vw',
                minHeight: '100vh',
                padding: '2rem',
            }}>
                <Box>

                    <Typography level={'h2'}>Auctions</Typography>
                </Box>
                <Box sx={{
                    display: 'flex'
                }}>
                    <Box>

                    </Box>
                    <List>
                        {
                            AuctionData.data.map(auction => (
                                <React.Fragment key={auction.auctionId}>
                                    <AuctionListItem auction={auction}/>
                                    <Divider
                                        sx={{
                                            maxWidth: '50rem'
                                        }}
                                    />
                                </React.Fragment>
                            ))
                        }
                    </List>
                </Box>
            </Box>
        </section>
    )
        ;
};

export default Bulk;
